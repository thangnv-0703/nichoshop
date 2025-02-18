using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NichoShop.Application.Interfaces;
using System.Net;

namespace NichoShop.Application.Controllers;

[Route("api/v1/location")]
[ApiController]
[Authorize]
public class LocationController : Controller
{
    private readonly ILocationService _locationService;
    private readonly ICacheService _redisService;

    public LocationController(ILocationService locationService, ICacheService redisService)
    {
        _locationService = locationService;
        _redisService = redisService;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetLocation(int type, string? parentCode)
    {
        var cacheKey = $"location_{type}_{parentCode}";

        var result = await _redisService.GetOrCreateAsync(cacheKey, async () =>
        {
            return await _locationService.GetLocationAsync(type, parentCode);
        });

        return Ok(result);
    }
}
