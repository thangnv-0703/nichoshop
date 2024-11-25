﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NichoShop.Domain.AggergateModels.ProductAggregate;

namespace NichoShop.Infrastructure.EntityConfigurations;
public class ProductCategoryEntityConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("product_categories");

        builder.HasKey(o => new { o.ProductId, o.CategoryId });
    }
}
