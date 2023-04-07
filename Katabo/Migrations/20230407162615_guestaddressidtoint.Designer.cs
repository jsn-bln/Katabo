﻿// <auto-generated />
using System;
using Katabo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Katabo.Migrations
{
    [DbContext(typeof(KataboContext))]
    [Migration("20230407162615_guestaddressidtoint")]
    partial class guestaddressidtoint
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Katabo.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"), 1L, 1);

                    b.Property<string>("Barangay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Landmark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            Barangay = "Maybacong",
                            City = "Borongan",
                            Country = "Philippines",
                            Landmark = "Near the chapel, red house",
                            Province = "Eastern Samar",
                            UserId = 2,
                            Zipcode = "6800"
                        },
                        new
                        {
                            AddressId = 2,
                            Barangay = "Sabang South",
                            City = "Borongan",
                            Country = "Philippines",
                            Landmark = "Fish port",
                            Province = "Eastern Samar",
                            UserId = 1,
                            Zipcode = "6800"
                        });
                });

            modelBuilder.Entity("Katabo.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CreatedDateTime = new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7381),
                            DisplayOrder = 1,
                            Name = "Seafoods"
                        },
                        new
                        {
                            CategoryId = 2,
                            CreatedDateTime = new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7385),
                            DisplayOrder = 2,
                            Name = "Meat"
                        },
                        new
                        {
                            CategoryId = 3,
                            CreatedDateTime = new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7390),
                            DisplayOrder = 3,
                            Name = "Vegetables"
                        },
                        new
                        {
                            CategoryId = 4,
                            CreatedDateTime = new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7393),
                            DisplayOrder = 4,
                            Name = "Fruits"
                        },
                        new
                        {
                            CategoryId = 5,
                            CreatedDateTime = new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7398),
                            DisplayOrder = 5,
                            Name = "Root Crops"
                        });
                });

            modelBuilder.Entity("Katabo.Models.Guest", b =>
                {
                    b.Property<int>("GuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuestId"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuestId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("Katabo.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("BillingAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsShipped")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderInstruction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShippingAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Katabo.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("OrderItemId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Katabo.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            Image = "/images/bangus.png",
                            Name = "Bangus",
                            Price = 150.0,
                            ProductDescription = "description",
                            ProductQuantity = 100
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 3,
                            Image = "/images/cabbage.png",
                            Name = "cabbage",
                            Price = 70.0,
                            ProductDescription = "description",
                            ProductQuantity = 100
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            Image = "/images/chicken-drumsticks.png",
                            Name = "Chicken Drumsticks",
                            Price = 200.0,
                            ProductDescription = "description",
                            ProductQuantity = 100
                        });
                });

            modelBuilder.Entity("Katabo.Models.ShoppingCarts", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartId"), 1L, 1);

                    b.Property<string>("CartJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ShoppingCartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Katabo.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("AddressId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNmber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("cPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("AddressId1");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            AddressId = 2,
                            Birthday = new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7545),
                            Email = "admin@admin.com",
                            FirstName = "admin",
                            Gender = "Male",
                            LastName = "admin",
                            Password = "password",
                            PhoneNmber = "09091234567",
                            Role = "Admin",
                            Username = "admin",
                            cPassword = "password"
                        },
                        new
                        {
                            UserId = 2,
                            AddressId = 1,
                            Birthday = new DateTime(2023, 4, 7, 12, 26, 14, 487, DateTimeKind.Local).AddTicks(7551),
                            Email = "user@user.com",
                            FirstName = "user",
                            Gender = "Female",
                            LastName = "user",
                            Password = "password",
                            PhoneNmber = "09091234567",
                            Role = "User",
                            Username = "user",
                            cPassword = "password"
                        });
                });

            modelBuilder.Entity("Katabo.Models.Order", b =>
                {
                    b.HasOne("Katabo.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Katabo.Models.User", b =>
                {
                    b.HasOne("Katabo.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId1");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Katabo.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
