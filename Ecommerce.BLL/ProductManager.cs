using Ecommerce.BLL.Abstraction.Base;
using Ecommerce.BLL.Abstractions.Contracts;
using Ecommerce.Models.DTO;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstract.Contracts;
using Ecommerce.Repositories.Abstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL
{
    public class ProductManager : Manager<Product>, IProductManager
    {
        IProductRepository productRepository;
        public ProductManager(IProductRepository repository) : base(repository)
        {
            productRepository = repository;
        }

        public ICollection<Product> GetByShopId(int shopId)
        {
            return productRepository.GetByShopId(shopId);
        }

        public ICollection<Product> Search(ProductSearchCriteriaDTO model)
        {
            return productRepository.Search(model);
        }

    }
}
