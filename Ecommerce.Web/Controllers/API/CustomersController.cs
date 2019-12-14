using Ecommerce.BLL.Abstractions.Contracts;
using Ecommerce.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Controllers.API
{
    [Route("api/customers")]
    public class CustomersController:ControllerBase
    {
        ICustomerManager _customerManager;

        public CustomersController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerManager.GetAll();

            if (customers!=null && customers.Any())
            {
                return Ok(customers);
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Customer model)
        {
            if (ModelState.IsValid)
            {
               bool isAdded = _customerManager.Add(model);
                if (isAdded)
                {
                    return Ok(model);
                }
            }

            return BadRequest(ModelState);
        }
    }
}
