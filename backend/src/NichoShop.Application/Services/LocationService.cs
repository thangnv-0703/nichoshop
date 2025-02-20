using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Application.Queries;

namespace NichoShop.Application.Services;

public class LocationService(IQueryService queryService, ICacheService redisService) : ILocationService
{
    private readonly IQueryService _queryService = queryService;
    private readonly ICacheService _redisService = redisService;

    public async Task<List<LocationViewModel>> GetLocationAsync(int type, string? parentCode)
    {
        var cacheKey = $"location_{type}_{parentCode}";

        var result = await _redisService.GetOrCreateAsync(cacheKey, async () =>
        {
            return await _queryService.GetLocationViewModelsAsync(type, parentCode);
        });

        return result;
    }
}
