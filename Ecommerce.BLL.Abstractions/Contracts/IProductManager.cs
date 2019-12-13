using Ecommerce.BLL.Abstraction.Contracts;
using Ecommerce.Models.DTO;
using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL.Abstractions.Contracts
{
   public  interface IProductManager:IManager<Product>
    {
        ICollection<Product> Search(ProductSearchCriteriaDTO model);
        ICollection<Product> GetByShopId(int shopId);
    }
}
