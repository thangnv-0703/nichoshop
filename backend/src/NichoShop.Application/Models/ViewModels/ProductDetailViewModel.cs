﻿using NichoShop.Domain.AggergateModels.ProductAggregate;
using NichoShop.Domain.AggergateModels.SkuAggregate;
using NichoShop.Domain.Enums;

namespace NichoShop.Application.Models.ViewModels
{
    public class ProductDetailViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public List<ProductCategoryViewModel> Categories { get; set; }
        public List<ProductAttributeValue> AttributeValues { get; set; }
        public List<ProductVariant> Variants { get; set; }
        public List<ProductImage> Images { get; set; }
        public List<Sku> Skus { get; set; }
    }

    public class ProductCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ParentId { get; set; }
    }
}
