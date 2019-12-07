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
    public class ProductsController : ControllerBase
    {
        IUnitOfWork _unitofWork;
        public ProductsController(IUnitOfWork unitOfWOrk)
        {
            _unitofWork = unitOfWOrk;
        }
        public IEnumerable<ProductVM> Get(ProductSearchCriteriaDTO model)
        {
            var products =
                _unitofWork
                .ProductRepository
                .Search(model)
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
            var product = _unitofWork.ProductRepository.GetById(id);

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
                _unitofWork.ProductRepository.Add(product);
                bool isSuccess = _unitofWork.SaveChanges();

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
                var existingProduct = _unitofWork.ProductRepository.GetById(id);

                if (existingProduct == null)
                {
                    return BadRequest("Product Not Found");
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.WarehouseLocation = product.WarehouseLocation;
                existingProduct.DokanId = product.DokanId;


                _unitofWork.ProductRepository.Update(existingProduct);
                bool isUpdated = _unitofWork.SaveChanges();
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
            var product = _unitofWork.ProductRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            _unitofWork.ProductRepository.Remove(product);
            bool isDeleted = _unitofWork.SaveChanges();
            if (isDeleted)
            {
                return Ok();
            }

            return BadRequest();
        }



    }
}
