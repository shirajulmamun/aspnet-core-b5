using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EcommerceApp.DatabaseContext
{
    public class EcommerceDbContext:DbContext
    {
        public EcommerceDbContext(DbContextOptions options):base(options)
        { 

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {       
          
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().ToTable("Customers");

            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .HasColumnName("CustomerName")
                .HasColumnType("varchar(250)");

            modelBuilder.Entity<Product>().HasQueryFilter(c => c.IsDeleted == false);

            base.OnModelCreating(modelBuilder);

        }
    }
}
