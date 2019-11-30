using Ecommerce.Library.Entity_Models;
using EcommerceApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Controllers
{
    public class PurchaseOrderController:Controller
    {
        UnitofWork _unitOfWork;

        public PurchaseOrderController()
        {
            _unitOfWork = new UnitofWork();
        }


        public IActionResult Create()
        {
            var products = _unitOfWork.ProductRepository.GetAll();
            ViewBag.Products = products.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name

            });
            return View();
        }

        [HttpPost]
        public IActionResult Create(PurchaseOrder model)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.PurchaseOrderRepository.Add(model);
                bool isSaved = _unitOfWork.SaveChanges();

            }





            var products = _unitOfWork.ProductRepository.GetAll();
            ViewBag.Products = products.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name

            });


            return View();
        }
    }
}
