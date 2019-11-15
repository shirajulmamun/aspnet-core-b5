using System;
using System.Collections.Generic;
using System.Text;
using EcommerceApp.Entity_Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.DatabaseContext
{
    public class EcommerceDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Shop> Shops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(local);Database=EcommerceDB5; Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionString);
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
