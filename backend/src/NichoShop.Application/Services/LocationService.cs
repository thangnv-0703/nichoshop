using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Application.Queries;

namespace NichoShop.Application.Services;

public class LocationService(IQueryService queryService) : ILocationService
{
    private readonly IQueryService _queryService = queryService;

    public async Task<List<LocationViewModel>> GetLocationAsync(int type, string parentCode)
    {
        return await _queryService.GetLocationViewModelsAsync(type, parentCode);
    }
}
