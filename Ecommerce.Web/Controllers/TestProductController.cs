using EcommerceApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Controllers
{
    public class TestProductController
    {
        ProductRepository _productRepository;

        public TestProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
