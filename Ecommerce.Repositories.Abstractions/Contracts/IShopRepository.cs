using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repositories.Abstractions.Contracts
{
   public interface IShopRepository:IRepository<Shop>
    {
        void LoadProducts(Shop shop);
        


    }
}
