using NichoShop.Application.Helpers;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Application.Queries;

namespace NichoShop.Application.Services;

public class CategoryService(IQueryService queryService, ICacheService redisService) : ICategoryService
{
    private readonly IQueryService _queryService = queryService;
    private readonly ICacheService _redisService = redisService;


    public async Task<List<CategoryViewModel>> GetCategoryAsync()
    {
        return await _redisService.GetOrCreateAsync(CacheKeys.Categories, _queryService.GetCategoryViewModelsAsync);
    }
}
