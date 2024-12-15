using MediatR;
using Microsoft.Extensions.Configuration;
using NichoShop.Domain.AggergateModels;
using NichoShop.Infrastructure;
using NichoShop.TestDataLoader.Features.RefitModels;
using System.Net;

namespace NichoShop.TestDataLoader.Features;

public record SyncShoppeDataCommand : IRequest { }

public class SyncShoppeDataCommandHandler(IShoppeApi shoppeApi, IConfiguration configuration, NichoShopDbContext context) : IRequestHandler<SyncShoppeDataCommand>
{
    private readonly IShoppeApi _shoppeApi = shoppeApi;
    private readonly IConfiguration _configuration = configuration;
    private readonly NichoShopDbContext _context = context;
    private readonly Dictionary<string, AttributeProduct> _attributeDict = [];
    private readonly Dictionary<int, Category> _categoryDict = [];
    public async Task Handle(SyncShoppeDataCommand request, CancellationToken cancellationToken)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        if (environment != "Development")
        {
            Console.WriteLine("This option is only for Development environment");
            return;
        }

        var cookie = _configuration["CookieShoppe"];

        if (string.IsNullOrEmpty(cookie)) return;

        var categoryIds = await SyncCategoryDataAsync(cookie);
        await SyncAttributeDataAsync(cookie, categoryIds);
    }

    private async Task<List<int>> SyncCategoryDataAsync(string cookie)
    {
        var response = await _shoppeApi.GetCategoryTreeAsync(
            SPC_CDS: "dc602070-5eba-42f7-bfe6-44eb62e6935b",    // SPC_CDS
            SPC_CDS_VER: "2",                                  // SPC_CDS_VER
            include_level: "3",                                // include_level
            version: "1.0.1",                                  // version
            locale: "vi",                                     // locale
            priority: "u=1, i",                                // priority
            session: "9B35983F9D4091BA",                        // sc-fe-session
            versionHeader: "21.72231",                         // sc-fe-ver
            cookie: cookie
        );

        if (!response.IsSuccessStatusCode || response?.Content?.Data?.List is null)
        {
            return [];
        }

        var categories = response.Content.Data.List;
        _context.Category.RemoveRange(_context.Category);
        await _context.SaveChangesAsync();

        // Prepare batch insert
        var categoryIds = new List<int>();

        foreach (var category in categories)
        {
            categoryIds.AddRange(InsertCategory(category));
        }

         await _context.SaveChangesAsync();
        return categoryIds;
    }

    private List<int> InsertCategory(CategoryShoppe categoryShoppe)
    {
        var ids = new List<int>
        {
            categoryShoppe.Id
        };

        int? parentId = categoryShoppe.ParentId == 0 ? null : categoryShoppe.ParentId;
        var category = new Category(categoryShoppe.Id, categoryShoppe.Name, categoryShoppe.DisplayName, parentId);

        _context.Category.Add(category);
        _categoryDict.Add(category.Id, category);

        foreach (var childCategory in categoryShoppe.Children)
        {
            ids.AddRange(InsertCategory(childCategory));
        }
        return ids;
    }

    private async Task SyncAttributeDataAsync(string cookie, List<int> categoryIds) 
    {
        _context.AttributeProduct.RemoveRange(_context.AttributeProduct);
        await _context.SaveChangesAsync();

        foreach (var categoryId in categoryIds)
        {
            var response = await _shoppeApi.GetAttributeTreeAsync(
                contentType: "application/json;charset=UTF-8",
                priority: "u=1, i",
                cookie: cookie,
                body: new AttributeTreeRequest
                {
                    CategoryId = categoryId,
                    Locale = "vi"
                },
                SPC_CDS: "ceccc5ce-6922-452a-865d-d6b2ed41e63a",
                SPC_CDS_VER: "2");

            if (!response.IsSuccessStatusCode || response?.Content?.Data?.List is null || response.Content.Data.List[0] is null || 
                response.Content.Data.List[0].AttributeTree is null)
            {
                continue;
            }
            var attributeResponses = response.Content.Data.List[0].AttributeTree;
            if (attributeResponses is null || attributeResponses.Count == 0 || (attributeResponses[0].AttributeId == 0 && attributeResponses[0].ValueId == 0))
            {
                continue;
            }

            foreach (var attributeResponse in attributeResponses)
            {
                InsertAttribute(attributeResponse, categoryId);
            }

        }
        await _context.SaveChangesAsync();
    }

    private void InsertAttribute(AttributeShoppe attributeShoppe, int? categoryId = null, int? originalAttributeParentId = null, int? parentId = null)
    {
        AttributeProduct attribute;

        if (_attributeDict.TryGetValue($"{attributeShoppe.Name}-{attributeShoppe.DisplayName}-{originalAttributeParentId}", out var dictValue))
        {
            attribute = dictValue;
        }
        else
        { 
            attribute = new AttributeProduct(
                attributeShoppe.Name,
                attributeShoppe.DisplayName,
                parentId,
                attributeShoppe.Mandatory,
                attributeShoppe.ValueId);
            _context.AttributeProduct.Add(attribute);

            _attributeDict.Add($"{attributeShoppe.Name}-{attributeShoppe.DisplayName}-{originalAttributeParentId}", attribute);
        }

        if (categoryId.HasValue && _categoryDict.TryGetValue((int)categoryId, out var category))
        {
            attribute.AddCategory(category);
        }

        foreach (var childAttribute in attributeShoppe.Children)
        {
            InsertAttribute(childAttribute, null, originalAttributeParentId ?? attributeShoppe.AttributeId, attribute.Id);
        }
    }
}

