using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repositories.Abstract.Contracts
{
    public interface IProductRepository:IRepository<Product>
    {
        ICollection<Product> GetByName(string name);
        ICollection<Product> Search(Models.DTO.ProductSearchCriteriaDTO criteria);
        ICollection<Product> GetByShopId(int shopId);
    }
}
