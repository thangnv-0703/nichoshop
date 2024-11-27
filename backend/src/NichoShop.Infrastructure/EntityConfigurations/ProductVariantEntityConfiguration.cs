using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NichoShop.Domain.AggergateModels.ProductAggregate;
using System.Text.Json;

namespace NichoShop.Infrastructure.EntityConfigurations;
public class ProductVariantEntityConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.ToTable("product_variants");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(pv => pv.Options)
                .HasConversion(
                    options => JsonSerializer.Serialize(options, (JsonSerializerOptions)null!),
                    json => JsonSerializer.Deserialize<List<ProductVariantOption>>(json!, (JsonSerializerOptions)null)
                )
                .HasColumnType("jsonb") // Use PostgreSQL's JSONB column type
                .HasColumnName("Options")
                .IsRequired()
                .Metadata.SetValueComparer(
                    new ValueComparer<IReadOnlyCollection<ProductVariantOption>>(
                    (c1, c2) => (c1 ?? new List<ProductVariantOption>()).SequenceEqual(c2 ?? new List<ProductVariantOption>()),
                    c => c == null ? 0 : c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c == null ? new List<ProductVariantOption>() : c.ToList())
                );
    }
}
