using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcommerceApp.DatabaseContext;
using EcommerceApp.Entity_Models;
using EcommerceApp.Migrations;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Repositories
{
    class ShopRepository
    {
        private EcommerceDbContext _db;

        public ShopRepository(EcommerceDbContext db)
        {
            _db= db;
        }
        public Shop GetById(int id)
        {
            return _db.Shops.Find(id);
        }

        public void Add(Shop shop)
        {
            _db.Shops.Add(shop);
        }

        public ICollection<Shop> GetAll()
        {
            return _db.Shops
                .ToList();
        }

        public void LoadProducts(Shop shop)
        {
            
            _db.Entry(shop)
                .Collection(c=>c.Products)
                .Load();
        }

        public void Update(Shop shop)
        {
            _db.Entry(shop).State = EntityState.Modified;
        }
    }
}
