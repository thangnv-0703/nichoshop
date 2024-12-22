using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NichoShop.Domain.AggergateModels.SkuAggregate;
using NichoShop.Domain.Enums;
using NichoShop.Domain.Shared;
using System.Text.Json;

namespace NichoShop.Infrastructure.EntityConfigurations;
public class SkuEntityConfiguration : IEntityTypeConfiguration<Sku>
{
    public void Configure(EntityTypeBuilder<Sku> builder)
    {
        builder.ToTable("skus");

        builder.Property(o => o.Id)
            .UseHiLo("SkuSeq");

        builder.Ignore(o => o.DomainEvents);

        builder.Property(o => o.SkuNo)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(o => o.ProductId)
            .IsRequired();

        builder.Property(pv => pv.SkuVariants)
             .HasConversion(
                 options => JsonSerializer.Serialize(options, (JsonSerializerOptions)null!),
                 json => JsonSerializer.Deserialize<List<SkuVariant>>(json!, (JsonSerializerOptions)null)
             )
             .HasColumnType("jsonb") // Use PostgreSQL's JSONB column type
             .HasColumnName("SkuVariants")
             .IsRequired()
             .Metadata.SetValueComparer(
                 new ValueComparer<IReadOnlyCollection<SkuVariant>>(
                 (c1, c2) => (c1 ?? new List<SkuVariant>()).SequenceEqual(c2 ?? new List<SkuVariant>()),
                 c => c == null ? 0 : c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                 c => c == null ? new List<SkuVariant>() : c.ToList())
             );

        builder.OwnsOne(o => o.Price, priceBuilder =>
        {
            priceBuilder.Property(p => p.Amount)
                .HasColumnName(nameof(Money.Amount))
                .HasColumnType("decimal(13,2)")
                .IsRequired(); // Ensure the column is not nullable

            priceBuilder.Property(p => p.Currency)
                .HasColumnName(nameof(Money.Currency))
                .HasConversion(
                    v => v.ToString(),
                    dbCurrency => (Currency)Enum.Parse(typeof(Currency), dbCurrency)
                );
        });

        builder.Property(o => o.Quantity)
            .IsRequired();
    }
}
