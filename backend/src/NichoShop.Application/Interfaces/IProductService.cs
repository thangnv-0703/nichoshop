using NichoShop.Application.Models.Dtos.Request.Product;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Domain.AggergateModels.ProductAggregate;

namespace NichoShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductDetailAsync(int productId);
        Task<List<ProductSearchViewModel>> GetProductSearchViewModelAsync(ProductSearchRequestDto param);
    }
}
