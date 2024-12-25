using NichoShop.Application.Models.ViewModels;

namespace NichoShop.Application.Queries;

public interface IQueryService
{
    Task<List<CategoryViewModel>> GetCategoryViewModelsAsync();
    Task<List<LocationViewModel>> GetLocationViewModelsAsync(int type, string parentCode);
    Task<List<CartItemViewModel>> GetCartItemViewModelsAsync(Guid userId);
}
