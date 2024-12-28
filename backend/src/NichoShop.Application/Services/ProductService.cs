using NichoShop.Application.Interfaces;
using NichoShop.Application.Queries;
using NichoShop.Domain.AggergateModels.ProductAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IQueryService _queryService;

        public ProductService(IProductRepository productRepository, IQueryService queryService)
        {
            _productRepository = productRepository;
            _queryService = queryService;
        }

        public async Task<Product> GetProductDetailAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId, includeDetail: true) ?? throw new Exception("Product not found");
            _queryService.GetCategoryTree(productId);
            return product;
        }
    }
}
