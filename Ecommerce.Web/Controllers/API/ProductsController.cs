using Ecommerce.BLL.Abstractions.Contracts;

using Ecommerce.Models.DTO;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.ViewModels.API.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Controllers.API
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        IProductManager _productManager;
        public ProductsController(IProductManager _productManager)
        {
            _productManager = _productManager;
        }
        public IEnumerable<ProductVM> Get(ProductSearchCriteriaDTO model)
        {
            var products =
                _productManager.Search(model)
                .Select(c => new ProductVM {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    WarehouseLocation = c.WarehouseLocation,
                    Dokan = new DokanVM {
                        DokanId = c.DokanId,
                        DokanName = c.Dokan?.Name
                    }

                });

            return products.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productManager.GetById(id);

            if (product == null)
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
                bool isSuccess = _productManager.Add(product);

                if (isSuccess)
                {
                    return Ok(product);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = _productManager.GetById(id);

                if (existingProduct == null)
                {
                    return BadRequest("Product Not Found");
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.WarehouseLocation = product.WarehouseLocation;
                existingProduct.DokanId = product.DokanId;


                bool isUpdated = _productManager.Update(existingProduct);
                if (isUpdated)
                {
                    return Ok();
                }
            }

            return BadRequest("Bad Request");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery] int id)
        {
            var product = _productManager.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            bool isDeleted = _productManager.Remove(product);
            if (isDeleted)
            {
                return Ok();
            }

            return BadRequest();
        }



    }
}
