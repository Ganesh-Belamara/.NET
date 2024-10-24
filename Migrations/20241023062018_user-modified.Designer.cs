﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductApi_Task.Data;

#nullable disable

namespace ProductApi_Task.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241023062018_user-modified")]
    partial class usermodified
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductApi_Task.Models.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartID"));

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("CartID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            CartID = 1,
                            ProductID = 1,
                            Quantity = 2,
                            UserID = 1
                        },
                        new
                        {
                            CartID = 2,
                            ProductID = 2,
                            Quantity = 1,
                            UserID = 2
                        });
                });

            modelBuilder.Entity("ProductApi_Task.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<decimal>("Total_Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            Total_Amount = 20.00m,
                            UserID = 1
                        },
                        new
                        {
                            OrderId = 2,
                            Total_Amount = 20.00m,
                            UserID = 2
                        });
                });

            modelBuilder.Entity("ProductApi_Task.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            Price = 10.00m,
                            ProductName = "Product 1"
                        },
                        new
                        {
                            ProductID = 2,
                            Price = 20.00m,
                            ProductName = "Product 2"
                        });
                });

            modelBuilder.Entity("ProductApi_Task.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            CreatedDate = new DateTime(2024, 10, 23, 6, 20, 16, 843, DateTimeKind.Utc).AddTicks(4446),
                            Email = "user1@example.com",
                            IsActive = true,
                            IsDeleted = false,
                            UserName = "user1"
                        },
                        new
                        {
                            UserID = 2,
                            CreatedDate = new DateTime(2024, 10, 23, 6, 20, 16, 843, DateTimeKind.Utc).AddTicks(4461),
                            Email = "user2@example.com",
                            IsActive = true,
                            IsDeleted = false,
                            UserName = "user2"
                        });
                });

            modelBuilder.Entity("ProductApi_Task.Models.Cart", b =>
                {
                    b.HasOne("ProductApi_Task.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductApi_Task.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProductApi_Task.Models.Order", b =>
                {
                    b.HasOne("ProductApi_Task.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
