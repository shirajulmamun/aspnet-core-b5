using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstraction.Base;
using Ecommerce.Repositories.Abstractions.Contracts;
using EcommerceApp.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcommerceApp.Repositories
{
    public class ShopRepository:Repository<Shop>,IShopRepository
    {
        private EcommerceDbContext _db;

        public ShopRepository(EcommerceDbContext db):base(db)
        {
            _db= db;
        }
        
        public void LoadProducts(Shop shop)
        {
            
            _db.Entry(shop)
                .Collection(c=>c.Products)
                .Load();
        }

      
    }
}
