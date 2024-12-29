using NichoShop.Application.Models.Dtos.Request.Product;
using NichoShop.Application.Models.ViewModels;

namespace NichoShop.Application.Queries;

public interface IQueryService
{
    Task<List<CategoryViewModel>> GetCategoryViewModelsAsync();
    Task<List<LocationViewModel>> GetLocationViewModelsAsync(int type, string parentCode);
    Task<List<CartItemViewModel>> GetCartItemViewModelsAsync(Guid userId);
    Task<List<ProductSearchViewModel>> GetProductSearchViewModelAsync(ProductSearchRequestDto param);
    Task<List<ProductCategoryViewModel>> GetCategoryTree(int categoryId);
}
