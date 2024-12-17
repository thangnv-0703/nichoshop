using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NichoShop.Domain.AggergateModels;
using NichoShop.Domain.AggergateModels.ProductAggregate;

namespace NichoShop.Infrastructure.EntityConfigurations;
public class ProductAttributeValueEntityConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
{
    public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
    {
        builder.ToTable("product_attribute_values");

        builder.Property<int>("Id")
            .UseHiLo("ProductAttributeValueSeq");

        builder.Property<int>("ProductId")
            .IsRequired();

        builder.Property(o => o.AttributeId)
            .IsRequired();

        builder.Property(o => o.RawValue)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(o => o.ValueId)
            .IsRequired();

        builder.HasOne<AttributeProduct>()
            .WithMany()
            .HasForeignKey(o => o.AttributeId);
    }
}
