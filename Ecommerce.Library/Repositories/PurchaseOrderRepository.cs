using Ecommerce.Library.Entity_Models;
using EcommerceApp.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Library.Repositories
{
    public class PurchaseOrderRepository
    {
        EcommerceDbContext _db;

        public PurchaseOrderRepository(EcommerceDbContext db)
        {
            _db = db;
        }
        public void Add(PurchaseOrder entity)
        {
            _db.PurchaseOrders.Add(entity);

            
        }
    }
}
