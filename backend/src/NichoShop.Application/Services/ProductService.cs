using NichoShop.Application.Interfaces;
using NichoShop.Domain.AggergateModels.ProductAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProductDetailAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId, includeDetail: true) ?? throw new Exception("Product not found");
            return product;
        }
    }
}
