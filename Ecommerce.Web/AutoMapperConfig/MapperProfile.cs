using AutoMapper;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.ViewModels.Web.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.AutoMapperConfig
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductCreateVM, Product>();
            CreateMap<Product, ProductCreateVM>();
            
        }

    }
}
