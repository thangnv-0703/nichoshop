using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NichoShop.Domain.AggergateModels;

namespace NichoShop.Infrastructure.EntityConfigurations;
public class ProductAttributeEntityConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.ToTable("attributes");

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.DisplayName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.ParentId)
            .IsRequired(false);

        builder.Property(a => a.Mandatory)
            .IsRequired();

        builder.HasOne(a => a.Parent)
            .WithMany(a => a.Children)
            .HasForeignKey(a => a.ParentId)
            .IsRequired(false);
    }
}