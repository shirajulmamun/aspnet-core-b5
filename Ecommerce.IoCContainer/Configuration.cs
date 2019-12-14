using Ecommerce.BLL;
using Ecommerce.BLL.Abstractions.Contracts;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Abstract.Contracts;
using Ecommerce.Repositories.Abstractions.Contracts;
using EcommerceApp.DatabaseContext;
using EcommerceApp.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.IoCContainer
{
    public static class IoCConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IShopManager, ShopManager>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IShopRepository, ShopRepository>();
            services.AddTransient<DbContext, EcommerceDbContext>();
            services.AddTransient<EcommerceDbContext>();
            services.AddTransient<ICustomerManager,CustomerManager>();
            services.AddTransient<ICustomerRepository,CustomerRepository>();
                
        }
    }
}
