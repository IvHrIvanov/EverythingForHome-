﻿// <auto-generated />
using System;
using DataBaseevEverythingForHome.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ProjectEverything.Migrations
{
    [DbContext(typeof(EverythingForHomeDBContext))]
    partial class EverythingForHomeDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataBaseevEverythingForHome.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime>("BirtDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(28)
                        .HasColumnType("nvarchar(28)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DataBaseevEverythingForHome.Models.ElectricPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PartElectric")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("ElectricsParts");
                });

            modelBuilder.Entity("DataBaseevEverythingForHome.Models.Maggazine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(28)
                        .HasColumnType("nvarchar(28)");

                    b.HasKey("Id");

                    b.ToTable("Maggazines");
                });

            modelBuilder.Entity("DataBaseevEverythingForHome.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int?>("BuyerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("OrderedProduct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataBaseevEverythingForHome.Models.WaterPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PartWater")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("WatersParts");
                });

            modelBuilder.Entity("DataBaseevEverythingForHome.Models.Account", b =>
                {
                    b.HasOne("DataBaseevEverythingForHome.Models.Maggazine", "Shop")
                        .WithMany("Accounts")
                        .HasForeignKey("ShopId");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("DataBaseevEverythingForHome.Models.ElectricPart", b =>
                {
                    b.HasOne("DataBaseevEverythingForHome.Models.Maggazine", "Shop")
                        .WithMany("ElectricParts")
                        .HasForeignKey("ShopId");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("DataBaseevEverythingForHome.Models.Order", b =>
                {
                    b.HasOne("DataBaseevEverythingForHome.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DataBaseevEverythingForHome.Models.WaterPart", b =>
                {
                    b.HasOne("DataBaseevEverythingForHome.Models.Maggazine", "Shop")
                        .WithMany("WaterParts")
                        .HasForeignKey("ShopId");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("DataBaseevEverythingForHome.Models.Maggazine", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("ElectricParts");

                    b.Navigation("WaterParts");
                });
#pragma warning restore 612, 618
        }
    }
}
