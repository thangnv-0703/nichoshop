using NichoShop.Application.Models.ViewModels;
using NichoShop.Domain.AggergateModels;

namespace NichoShop.Application.Queries;

public interface IQueryService
{
    Task<List<CategoryViewModel>> GetCategoryViewModelsAsync();
    Task<List<LocationViewModel>> GetLocationViewModelsAsync(int type, string parentCode);
    Task<List<CartItemViewModel>> GetCartItemViewModelsAsync(Guid userId);
    Task<List<Category>> GetCategoryTree(int categoryId);
}
