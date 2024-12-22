using NichoShop.Domain.AggergateModels.ProductAggregate;

namespace NichoShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductDetailAsync(int productId);
    }
}
