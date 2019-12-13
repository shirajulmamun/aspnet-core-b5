
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstraction.Base;
using Ecommerce.Repositories.Abstractions.Contracts;
using EcommerceApp.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Library.Repositories
{
    public class PurchaseOrderRepository:Repository<PurchaseOrder>,IPurchaseOrderRepository
    {
        EcommerceDbContext _db;

        public PurchaseOrderRepository(EcommerceDbContext db):base(db)
        {
            _db = db;
        }
        
    }
}
