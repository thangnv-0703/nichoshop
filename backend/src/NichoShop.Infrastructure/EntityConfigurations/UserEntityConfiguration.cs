using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Shared;
using System.Reflection.Emit;

namespace NichoShop.Infrastructure.EntityConfigurations;
public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.Ignore(o => o.DomainEvents);

        builder.Property(o => o.Id)
            .ValueGeneratedOnAdd();

        builder.Property(o => o.Id)
            .ValueGeneratedOnAdd();

        builder.Property(o => o.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(o => o.FullName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(o => o.UserName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(o => o.Password)
            .IsRequired();

        builder.Property(o => o.Gender)
            .HasConversion<int>()
            .IsRequired(false);

        builder.OwnsOne(o => o.PhoneNumber, phoneBuilder =>
        {
            phoneBuilder.Property(p => p.Value)
                .HasColumnType("varchar(15)")
                .HasColumnName(nameof(User.PhoneNumber))
                .HasMaxLength(15)
                .IsRequired(); 
        });

        var navigation = builder.Metadata.FindNavigation(nameof(User.Addresses))!;
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
