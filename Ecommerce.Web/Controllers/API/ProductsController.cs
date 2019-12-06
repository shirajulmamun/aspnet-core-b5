using Ecommerce.Library.DTO;
using Ecommerce.Library.ViewModels.API.Products;
using EcommerceApp.Entity_Models;
using EcommerceApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Controllers.API
{
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        UnitofWork unitofWork;
        public ProductsController()
        {
            unitofWork = new UnitofWork();
        }
        public IEnumerable<ProductVM> Get(ProductSearchCriteriaDTO model)
        {
            var products = 
                unitofWork
                .ProductRepository
                .Search(model)
                .Select(c=> new ProductVM{
                Id = c.Id,
                Name = c.Name,
                Price = c.Price,
                WarehouseLocation=c.WarehouseLocation,
                Dokan = new DokanVM {
                    DokanId = c.DokanId,
                    DokanName= c.Dokan?.Name
                }

            });

            return products.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = unitofWork.ProductRepository.GetById(id);

            if(product == null)
            {
                return NotFound();
            }

            var productVm = new ProductVM
            {
                Name = product.Name,
                WarehouseLocation = product.WarehouseLocation,
                Price = product.Price,
                Id = product.Id,
                Dokan = new DokanVM()
                {
                    DokanId = product.DokanId,
                    DokanName = product.Dokan?.Name
                }
            };

            return Ok(productVm);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                unitofWork.ProductRepository.Add(product);
                bool isSuccess = unitofWork.SaveChanges();

                if (isSuccess)
                {
                    return Ok(product);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
