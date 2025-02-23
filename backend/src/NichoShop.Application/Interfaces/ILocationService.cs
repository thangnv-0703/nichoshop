using NichoShop.Application.Models.ViewModels;

namespace NichoShop.Application.Interfaces;

public interface ILocationService
{
    Task<List<LocationViewModel>> GetLocationAsync(int type, string? parentCode);
}
