using Microsoft.EntityFrameworkCore;
using NichoShop.Application.Enums;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Domain.AggergateModels;
using NichoShop.Infrastructure;
using Npgsql;
using System.Data;

namespace NichoShop.Application.Queries;
public class QueryService(NichoShopDbContext dbContext) : IQueryService
{
    private readonly NichoShopDbContext _dbContext = dbContext;

    public async Task<List<CategoryViewModel>> GetCategoryViewModelsAsync()
    {
        return await _dbContext.Category
            .Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                DisplayName = c.DisplayName
            })
            .ToListAsync();
    }

    public async Task<List<LocationViewModel>> GetLocationViewModelsAsync(int type, string parentCode)
    {
        // Get provinces
        if (type == (int)LocationType.Province)
        {
            return await _dbContext.Province
                .Select(c => new LocationViewModel
                {
                    Code = c.Code,
                    Name = c.Name,
                    FullName = c.FullName,
                    NameEn = c.NameEn,
                    FullNameEn = c.FullNameEn,
                    CodeName = c.CodeName,
                })
                .ToListAsync();
        }
        // Get districts
        else if (type == (int)LocationType.District)
        {
            return await _dbContext.District
                .Where(x => x.ProvinceCode == parentCode)
                .Select(c => new LocationViewModel
                {
                    Code = c.Code,
                    Name = c.Name,
                    FullName = c.FullName,
                    NameEn = c.NameEn,
                    FullNameEn = c.FullNameEn,
                    CodeName = c.CodeName,
                })
                .ToListAsync();
        }
        // Get wards
        else if (type == (int)LocationType.Ward)
        {
            return await _dbContext.Ward
                .Where(x => x.DistrictCode == parentCode)
                .Select(c => new LocationViewModel
                {
                    Code = c.Code,
                    Name = c.Name,
                    FullName = c.FullName,
                    NameEn = c.NameEn,
                    FullNameEn = c.FullNameEn,
                    CodeName = c.CodeName,
                })
                .ToListAsync();
        }
        return new List<LocationViewModel>();
    }

    public async Task<List<CartItemViewModel>> GetCartItemViewModelsAsync(Guid userId)
    {
        var res = new List<CartItemViewModel>();
        var paramUserId = new NpgsqlParameter("@userId", userId);

        string query = $@"
            SELECT
              ci.""Id"",
              p.""Name"" AS ProductName,
              STRING_AGG(attr ->> 'value', ', ') AS ProductVariantName,
              s.""Amount"" AS Price,
              ci.""Quantity"",
              s.""Currency""
            FROM shopping_carts sc
                   LEFT JOIN cart_items ci
                     ON sc.""Id"" = ci.""ShoppingCartId""
                   LEFT JOIN skus s
                     ON ci.""SkuId"" = s.""Id""
                   LEFT JOIN products p
                     ON p.""Id"" = s.""ProductId"",
                 LATERAL jsonb_array_elements(s.""SkuVariants"") AS attr
            WHERE sc.""CustomerId"" = '{userId.ToString()}'
            GROUP BY ci.""Id"",
                     p.""Name"",
                     s.""Amount"",
                     ci.""Quantity"",
                     s.""Currency"";";

        var cartItems = await _dbContext.Database.ExecuteSqlRawAsync(query);

        using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            await _dbContext.Database.OpenConnectionAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var cartItem = new CartItemViewModel
                    {
                        Id = reader.GetGuid(0),
                        ProductName = reader.GetString(1),
                        ProductVariantName = reader.GetString(2),
                        Amount = reader.GetDecimal(3),
                        Quantity = reader.GetInt32(4),
                        Currency = reader.GetString(5),
                    };
                    res.Add(cartItem);
                }
            }
            await _dbContext.Database.CloseConnectionAsync();
        }
        return res;
    }
    public async Task<List<Category>> GetCategoryTree(int productId)
    {
        var res = new List<Category>();
        var paramUserId = new NpgsqlParameter("@productId", productId);

        string query = $@"
            SELECT
              ci.""Id"",
              p.""Name"" AS ProductName,
              STRING_AGG(attr ->> 'value', ', ') AS ProductVariantName,
              s.""Amount"" AS Price,
              ci.""Quantity"",
              s.""Currency""
            FROM shopping_carts sc
                   LEFT JOIN cart_items ci
                     ON sc.""Id"" = ci.""ShoppingCartId""
                   LEFT JOIN skus s
                     ON ci.""SkuId"" = s.""Id""
                   LEFT JOIN products p
                     ON p.""Id"" = s.""ProductId"",
                 LATERAL jsonb_array_elements(s.""SkuVariants"") AS attr
            WHERE sc.""CustomerId"" = '{productId.ToString()}'
            GROUP BY ci.""Id"",
                     p.""Name"",
                     s.""Amount"",
                     ci.""Quantity"",
                     s.""Currency"";";

        var cartItems = await _dbContext.Database.ExecuteSqlRawAsync(query);

        using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            await _dbContext.Database.OpenConnectionAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var cartItem = new Category
                    (
                       reader.GetInt32(1),
                       reader.GetString(2),
                       reader.GetString(3),
                       reader.GetInt32(4)
                    );
                    res.Add(cartItem);
                }
            }
            await _dbContext.Database.CloseConnectionAsync();
        }
        return res;
    }
}
