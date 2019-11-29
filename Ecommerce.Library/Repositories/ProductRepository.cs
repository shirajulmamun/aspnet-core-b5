using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcommerceApp.Contracts;
using EcommerceApp.DatabaseContext;
using Ecommerce.Library.DTO;
using EcommerceApp.Entity_Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Repositories
{
    public class ProductRepository
    {
        private EcommerceDbContext _db;

        public ProductRepository(EcommerceDbContext db)
        {
            _db = db;
        }
        public void Add(Product entity)
        {
            _db.Products.Add(entity);
            //return _db.SaveChanges() > 0;

        }

        public void Update(Product entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            //return _db.SaveChanges() > 0;
        }

        public void Remove(Product entity)
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

        public Product GetById(int id)
        {
            return _db.Products.Find(id);
        }


        public ICollection<Product> GetByName(string name)
        {

            var products = _db.Products
                            .Where(product => product.Name.Contains(name));

            return products.ToList();



        }


        public ICollection<Product> Search(ProductSearchCriteriaDTO criteria)
        {
            var products = _db.Products.AsEnumerable();

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

            return products.ToList();
        }

        public ICollection<Product> GetAll()
        {
            return _db.Products.Include(c=>c.Dokan).ToList();
        }

        public ICollection<Product> GetByShopId(int shopId)
        {
            return _db.Products.Where(c => c.DokanId == shopId).ToList();
        }
    }
}
