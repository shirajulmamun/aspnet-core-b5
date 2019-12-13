using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcommerceApp.Contracts;
using EcommerceApp.DatabaseContext;
using Ecommerce.Library.DTO;
using EcommerceApp.Entity_Models;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Library.Repositories;

namespace EcommerceApp.Repositories
{
    public class ProductRepository:Repository<Product>
    {
        private EcommerceDbContext _db;

        public ProductRepository(DbContext db):base(db)
        {
            _db = (EcommerceDbContext)db;
        }
      
              

        public override void Remove(Product entity)
        {
            if (entity is IDeleteable)
            {
                IDeleteable item = (IDeleteable)entity;
                item.IsDeleted = true;
                Update(entity);
            }
            else
            {
                _db.Products.Remove(entity);
               
            }
        }

        public override Product GetById(int id)
        {
            return _db.Products.Include(c=>c.Dokan).FirstOrDefault(c=>c.Id==id);
        }


        public ICollection<Product> GetByName(string name)
        {

            var products = _db.Products
                            .Where(product => product.Name.Contains(name));

            return products.ToList();



        }


        public ICollection<Product> Search(ProductSearchCriteriaDTO criteria)
        {
            var products = _db.Products.Include(c=>c.Dokan).AsEnumerable();

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                products = products.Where(c => c.Name.ToLower().Contains(criteria.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(criteria.Code))
            {
                products = products.Where(c => c.Code.ToLower().Contains(criteria.Code));
            }
            if (criteria.FromSalesPrice > 0)
            {
                products = products.Where(c => c.Price >= criteria.FromSalesPrice);
            }

            if (criteria.ToSalesPrice>0)
            {
                products = products.Where(c => c.Price <= criteria.ToSalesPrice);

            }

            if (criteria.DokanId!=null && criteria.DokanId > 0)
            {
                products = products.Where(c => c.DokanId == criteria.DokanId);
            }

            return products.ToList();
        }

        public override ICollection<Product> GetAll()
        {
            return _db.Products.Include(c=>c.Dokan).ToList();
        }

        public ICollection<Product> GetByShopId(int shopId)
        {
            return _db.Products.Where(c => c.DokanId == shopId).ToList();
        }
    }
}
