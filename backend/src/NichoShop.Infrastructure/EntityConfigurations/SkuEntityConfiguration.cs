using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NichoShop.Domain.AggergateModels;
using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Enums;
using NichoShop.Domain.Shared;

namespace NichoShop.Infrastructure.EntityConfigurations;
public class SkuEntityConfiguration : IEntityTypeConfiguration<Sku>
{
    public void Configure(EntityTypeBuilder<Sku> builder)
    {
        builder.ToTable("skus");

        builder.Ignore(o => o.DomainEvents);

        builder.Property(o => o.SkuNo)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(o => o.ProductId)
            .IsRequired();

        builder.Property(o => o.ProducVarianttName)
            .HasMaxLength(50)
            .IsRequired(false);

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
