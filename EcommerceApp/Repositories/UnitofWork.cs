using System;
using System.Collections.Generic;
using System.Text;
using EcommerceApp.DatabaseContext;

namespace EcommerceApp.Repositories
{
    class UnitofWork
    {
        private EcommerceDbContext _db;

        public UnitofWork()
        {
            _db = new EcommerceDbContext();
        }

        private ProductRepository _productRepository;
        private ShopRepository _shopRepository;

        public ProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_db);
                }

                return _productRepository;
            }
        }

        public ShopRepository ShopRepository
        {
            get
            {
                if (_shopRepository == null)
                {
                    _shopRepository = new ShopRepository(_db);
                }

                return _shopRepository;
            }
        }


        public bool SaveChanges()
        {
            return _db.SaveChanges() > 0;
        }
    }
}
