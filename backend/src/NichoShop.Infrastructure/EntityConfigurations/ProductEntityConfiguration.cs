using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NichoShop.Domain.AggergateModels.ProductAggregate;
using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Enums;

namespace NichoShop.Infrastructure.EntityConfigurations;
public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");  

        builder.Property(o => o.Id)
            .UseHiLo("ProductSeq");

        builder.Ignore(o => o.DomainEvents);

        builder.Property(o => o.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(o => o.Description)
            .HasMaxLength(3000)
            .IsRequired();

        builder.Property(o => o.Status)
            .HasConversion(
                o => o.ToString(),
                o => Enum.Parse<ProductStatus>(o)
            );

        var variantNavigation = builder.Metadata.FindNavigation(nameof(Product.Variants))!;
        variantNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        var attributeNvigation = builder.Metadata.FindNavigation(nameof(Product.AttributeValues))!;
        attributeNvigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
