using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Application.Queries;

namespace NichoShop.Application.Services;

public class CategoryService(IQueryService queryService) : ICategoryService
{
    private readonly IQueryService _queryService = queryService;

    public async Task<List<CategoryViewModel>> GetCategoryAsync()
    {
        return await _queryService.GetCategoryViewModelsAsync();
    }
}
