using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Library.Entity_Models;
using EcommerceApp.Entity_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EcommerceApp.DatabaseContext
{
    public class EcommerceDbContext:DbContext
    {
        IConfiguration _configuration;

        public EcommerceDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           var connString =  _configuration.GetConnectionString("AppConnectionString");
           optionsBuilder.UseSqlServer(connString);
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.Code);
            modelBuilder.Entity<Customer>().ToTable("clients");

            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .HasColumnName("CustomerName")
                .HasColumnType("varchar(250)");

            modelBuilder.Entity<Product>().HasQueryFilter(c => c.IsDeleted == false);

            base.OnModelCreating(modelBuilder);

        }
    }
}
