using AutoMapper;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.Product;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Application.Queries;
using NichoShop.Domain.Exceptions;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IQueryService _queryService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IQueryService queryService, IMapper mapper)
        {
            _productRepository = productRepository;
            _queryService = queryService;
            _mapper = mapper;
        }

        public async Task<ProductDetailViewModel> GetProductDetailAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId, includeDetail: true) ?? throw new NotFoundException("Product not found");
            var productDetailViewModel = _mapper.Map<ProductDetailViewModel>(product);
            if (product?.Categories != null && product.Categories.Count > 0)
            {
                productDetailViewModel.Categories = await _queryService.GetCategoryTree(product.Categories.ToList()[0].CategoryId);
            }
            return productDetailViewModel;
        }

        public async Task<List<ProductSearchViewModel>> GetProductSearchViewModelAsync(ProductSearchRequestDto param)
        {
            return await _queryService.GetProductSearchViewModelAsync(param);
        }
    }
}
