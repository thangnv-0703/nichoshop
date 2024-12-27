using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.Product;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Application.Queries;
using NichoShop.Domain.AggergateModels.ProductAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IQueryService _queryService;
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IQueryService queryService)
        {
            _productRepository = productRepository;
            _queryService = queryService;
        }

        public async Task<Product> GetProductDetailAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId, includeDetail: true) ?? throw new Exception("Product not found");
            return product;
        }

        public async Task<List<ProductSearchViewModel>> GetProductSearchViewModelAsync(ProductSearchRequestDto param)
        {
            return await _queryService.GetProductSearchViewModelAsync(param);
        }
    }
}
