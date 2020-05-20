﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserStocksBroker.Data;

namespace UserStocksBroker.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserStocksBroker.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Buyer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FullPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Seller")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Stock");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Buyer = "buyer",
                            FullPrice = 1.1000000000000001,
                            Name = "flow",
                            Price = 1.0,
                            Quantity = 1,
                            Seller = "seller",
                            TimeStamp = new DateTime(2020, 5, 20, 22, 23, 14, 71, DateTimeKind.Local).AddTicks(3921),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Buyer = "buyer",
                            FullPrice = 1.1000000000000001,
                            Name = "flow",
                            Price = 1.0,
                            Quantity = 1,
                            Seller = "seller",
                            TimeStamp = new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8513),
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Buyer = "buyer",
                            FullPrice = 1.1000000000000001,
                            Name = "flow",
                            Price = 1.0,
                            Quantity = 1,
                            Seller = "seller",
                            TimeStamp = new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8617),
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Buyer = "buyer",
                            FullPrice = 1.1000000000000001,
                            Name = "flow",
                            Price = 1.0,
                            Quantity = 1,
                            Seller = "seller",
                            TimeStamp = new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8623),
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            Buyer = "buyer",
                            FullPrice = 1.1000000000000001,
                            Name = "flow",
                            Price = 1.0,
                            Quantity = 1,
                            Seller = "seller",
                            TimeStamp = new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8626),
                            UserId = 2
                        },
                        new
                        {
                            Id = 6,
                            Buyer = "buyer",
                            FullPrice = 1.1000000000000001,
                            Name = "flow",
                            Price = 1.0,
                            Quantity = 1,
                            Seller = "seller",
                            TimeStamp = new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8629),
                            UserId = 2
                        },
                        new
                        {
                            Id = 7,
                            Buyer = "buyer",
                            FullPrice = 1.1000000000000001,
                            Name = "flow",
                            Price = 1.0,
                            Quantity = 1,
                            Seller = "seller",
                            TimeStamp = new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8632),
                            UserId = 3
                        },
                        new
                        {
                            Id = 8,
                            Buyer = "buyer",
                            FullPrice = 1.1000000000000001,
                            Name = "flow",
                            Price = 1.0,
                            Quantity = 1,
                            Seller = "seller",
                            TimeStamp = new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8635),
                            UserId = 3
                        },
                        new
                        {
                            Id = 9,
                            Buyer = "buyer",
                            FullPrice = 1.1000000000000001,
                            Name = "flow",
                            Price = 1.0,
                            Quantity = 1,
                            Seller = "seller",
                            TimeStamp = new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8638),
                            UserId = 3
                        });
                });

            modelBuilder.Entity("UserStocksBroker.Models.UserStockCollection", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        },
                        new
                        {
                            Id = 3
                        });
                });

            modelBuilder.Entity("UserStocksBroker.Models.Stock", b =>
                {
                    b.HasOne("UserStocksBroker.Models.UserStockCollection", "User")
                        .WithMany("Stocks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
