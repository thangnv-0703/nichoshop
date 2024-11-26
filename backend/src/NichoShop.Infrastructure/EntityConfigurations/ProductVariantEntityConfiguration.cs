using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NichoShop.Domain.AggergateModels.ProductAggregate;
using System.Text.Json;

namespace NichoShop.Infrastructure.EntityConfigurations;
public class ProductVariantEntityConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.ToTable("product_variants");

        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(pv => pv.Options)
            .HasConversion(
                options => JsonSerializer.Serialize(options.Select(o => o.Value), (JsonSerializerOptions)null!), // Serialize to JSON
                json => json != null
                    ? JsonSerializer.Deserialize<List<string>>(json, (JsonSerializerOptions)null!)!
                        .Select(value => new ProductVariantOption(value))
                        .ToList()!
                    : new List<ProductVariantOption>()
            )
            .HasColumnName("Options")
            .IsRequired(false);
    }
}
