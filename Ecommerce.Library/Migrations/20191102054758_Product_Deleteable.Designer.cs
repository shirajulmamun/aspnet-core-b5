﻿// <auto-generated />
using System;
using EcommerceApp.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EcommerceApp.Migrations
{
    [DbContext(typeof(EcommerceDbContext))]
    [Migration("20191102054758_Product_Deleteable")]
    partial class Product_Deleteable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EcommerceApp.Entity_Models.Customer", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name")
                        .HasColumnName("CustomerName")
                        .HasColumnType("varchar(250)");

                    b.HasKey("Code");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("EcommerceApp.Entity_Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(11);

                    b.Property<string>("DeleteRemarks");

                    b.Property<int?>("DeletedById");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<int?>("DokanId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<string>("WarehouseLocation");

                    b.HasKey("Id");

                    b.HasIndex("DokanId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EcommerceApp.Entity_Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("EcommerceApp.Entity_Models.Product", b =>
                {
                    b.HasOne("EcommerceApp.Entity_Models.Shop", "Dokan")
                        .WithMany("Products")
                        .HasForeignKey("DokanId");
                });
#pragma warning restore 612, 618
        }
    }
}
