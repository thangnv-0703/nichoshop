﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NichoShop.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NichoShop.Application.Migrations
{
    [DbContext(typeof(NichoShopDbContext))]
    [Migration("20241130091202_UpdateUserAuthen")]
    partial class UpdateUserAuthen
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence<int>("ProductAttributeValueSeq")
                .StartsAt(100000L)
                .IncrementsBy(100);

            modelBuilder.HasSequence<int>("ProductSeq")
                .StartsAt(10000000L)
                .IncrementsBy(10);

            modelBuilder.HasSequence<int>("SkuSeq")
                .StartsAt(100000L)
                .IncrementsBy(10);

            modelBuilder.Entity("Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<double>("Discount")
                        .HasColumnType("decimal(13,2)");

                    b.Property<DateTimeOffset>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("ShippingFee")
                        .HasColumnType("decimal(13,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.OrderAggregate.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("SkuId")
                        .HasColumnType("integer");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("VariantName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("order_items", (string)null);
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ProductAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "ProductSeq");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("character varying(3000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ProductAggregate.ProductAttributeValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "ProductAttributeValueSeq");

                    b.Property<int>("AttributeId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("RawValue")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("ValueId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("product_attribute_values", (string)null);
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ProductAggregate.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("ProductId", "CategoryId");

                    b.ToTable("product_categories", (string)null);
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ProductAggregate.ProductVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Options")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("Options");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("product_variants", (string)null);
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ProductAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("Mandatory")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<int>("ValueId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("attributes", (string)null);
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ShoppingCartAggregate.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("ShoppingCartId")
                        .HasColumnType("uuid");

                    b.Property<int>("SkuId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("cart_items", (string)null);
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ShoppingCartAggregate.ShoppingCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("shopping_carts", (string)null);
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.Sku", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "SkuSeq");

                    b.Property<bool>("InActive")
                        .HasColumnType("boolean");

                    b.Property<string>("ProducVarianttName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("SkuNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("skus", (string)null);
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("PasswordHashed")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.UserAggregate.UserAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_addresses", (string)null);
                });

            modelBuilder.Entity("Category", b =>
                {
                    b.HasOne("Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.OrderAggregate.Order", b =>
                {
                    b.OwnsOne("NichoShop.Domain.AggergateModels.OrderAggregate.ShippingAddress", "ShippingAddress", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FullName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("OrderFullName");

                            b1.Property<string>("OtherDetails")
                                .HasMaxLength(200)
                                .HasColumnType("character varying(200)")
                                .HasColumnName("OrderOtherDetails");

                            b1.HasKey("OrderId");

                            b1.ToTable("orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");

                            b1.OwnsOne("NichoShop.Domain.AggergateModels.OrderAggregate.Address", "Address", b2 =>
                                {
                                    b2.Property<Guid>("ShippingAddressOrderId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Country")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("character varying(50)")
                                        .HasColumnName("OrderCountry");

                                    b2.Property<string>("District")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("character varying(50)")
                                        .HasColumnName("OrderDistrict");

                                    b2.Property<string>("Province")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("character varying(50)")
                                        .HasColumnName("OrderProvince");

                                    b2.Property<string>("Street")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("character varying(100)")
                                        .HasColumnName("OrderStreet");

                                    b2.Property<string>("Ward")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("character varying(50)")
                                        .HasColumnName("OrderWard");

                                    b2.HasKey("ShippingAddressOrderId");

                                    b2.ToTable("orders");

                                    b2.WithOwner()
                                        .HasForeignKey("ShippingAddressOrderId");
                                });

                            b1.OwnsOne("NichoShop.Domain.Shared.PhoneNumber", "PhoneNumber", b2 =>
                                {
                                    b2.Property<Guid>("ShippingAddressOrderId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(15)
                                        .HasColumnType("varchar(15)")
                                        .HasColumnName("OrderPhoneNumber");

                                    b2.HasKey("ShippingAddressOrderId");

                                    b2.ToTable("orders");

                                    b2.WithOwner()
                                        .HasForeignKey("ShippingAddressOrderId");
                                });

                            b1.Navigation("Address")
                                .IsRequired();

                            b1.Navigation("PhoneNumber")
                                .IsRequired();
                        });

                    b.Navigation("ShippingAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.OrderAggregate.OrderItem", b =>
                {
                    b.HasOne("NichoShop.Domain.AggergateModels.OrderAggregate.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("NichoShop.Domain.Shared.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("OrderItemId")
                                .HasColumnType("uuid");

                            b1.Property<double>("Amount")
                                .HasColumnType("decimal(13,2)")
                                .HasColumnName("Amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Currency");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("order_items");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ProductAggregate.ProductAttributeValue", b =>
                {
                    b.HasOne("NichoShop.Domain.AggergateModels.ProductAggregate.Product", null)
                        .WithMany("AttributeValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ProductAggregate.ProductCategory", b =>
                {
                    b.HasOne("NichoShop.Domain.AggergateModels.ProductAggregate.Product", null)
                        .WithMany("Categories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ProductAggregate.ProductVariant", b =>
                {
                    b.HasOne("NichoShop.Domain.AggergateModels.ProductAggregate.Product", null)
                        .WithMany("Variants")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ProductAttribute", b =>
                {
                    b.HasOne("NichoShop.Domain.AggergateModels.ProductAttribute", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ShoppingCartAggregate.CartItem", b =>
                {
                    b.HasOne("NichoShop.Domain.AggergateModels.ShoppingCartAggregate.ShoppingCart", null)
                        .WithMany("Items")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.Sku", b =>
                {
                    b.OwnsOne("NichoShop.Domain.Shared.Money", "Price", b1 =>
                        {
                            b1.Property<int>("SkuId")
                                .HasColumnType("integer");

                            b1.Property<double>("Amount")
                                .HasColumnType("decimal(13,2)")
                                .HasColumnName("Amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Currency");

                            b1.HasKey("SkuId");

                            b1.ToTable("skus");

                            b1.WithOwner()
                                .HasForeignKey("SkuId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.UserAggregate.User", b =>
                {
                    b.OwnsOne("NichoShop.Domain.Shared.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar(15)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.UserAggregate.UserAddress", b =>
                {
                    b.HasOne("NichoShop.Domain.AggergateModels.UserAggregate.User", null)
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("NichoShop.Domain.Shared.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("UserAddressId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar(15)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("UserAddressId");

                            b1.ToTable("user_addresses");

                            b1.WithOwner()
                                .HasForeignKey("UserAddressId");
                        });

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });

            modelBuilder.Entity("Category", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.OrderAggregate.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ProductAggregate.Product", b =>
                {
                    b.Navigation("AttributeValues");

                    b.Navigation("Categories");

                    b.Navigation("Variants");
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ProductAttribute", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.ShoppingCartAggregate.ShoppingCart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("NichoShop.Domain.AggergateModels.UserAggregate.User", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
