using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NichoShop.Domain.AggergateModels.ProductAggregate;

namespace NichoShop.Infrastructure.EntityConfigurations;
public class ProductImageEntityConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable("product_images");

        builder.HasKey(o => new { o.ProductId, o.FileId });
    }
}
