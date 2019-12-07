﻿using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Library.Repositories;
using EcommerceApp.DatabaseContext;

namespace EcommerceApp.Repositories
{
    public class UnitofWork:IUnitOfWork
    {
        private EcommerceDbContext _db;

        public UnitofWork(EcommerceDbContext db)
        {
            _db = db;
        }

        private ProductRepository _productRepository;
        private ShopRepository _shopRepository;
        private PurchaseOrderRepository _purchaseOrderRepository;

        ProductRepository IUnitOfWork.ProductRepository
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

        public PurchaseOrderRepository PurchaseOrderRepository
        {
            get
            {
                if (_purchaseOrderRepository == null)
                {
                    _purchaseOrderRepository = new PurchaseOrderRepository(_db);
                }

                return _purchaseOrderRepository;
            }

        }

      
        public bool SaveChanges()
        {
            return _db.SaveChanges() > 0;
        }
    }
}
