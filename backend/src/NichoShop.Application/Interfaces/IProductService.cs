using NichoShop.Application.Models.Dtos.Request.Product;
using NichoShop.Application.Models.ViewModels;

namespace NichoShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDetailViewModel> GetProductDetailAsync(int productId);
        Task<List<ProductSearchViewModel>> GetProductSearchViewModelAsync(ProductSearchRequestDto param);
        Task<List<ProductsByCategoryDto>> GetProductsByCategoryAsync(int categoryId);
    }
}
