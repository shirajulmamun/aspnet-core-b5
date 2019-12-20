using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Ecommerce.BLL.Abstractions.Contracts;

using Ecommerce.Models.DTO;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.ViewModels.Web.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;

namespace Ecommerce.Web.Controllers
{
    public class ProductsController : Controller
    {
        IProductManager _productManager;
        IShopManager _shopManager;
        IMapper _mapper;

        public ProductsController(IProductManager productManager,IShopManager shopManager,IMapper mapper)
        {
            _productManager = productManager;
            _shopManager = shopManager;
            _mapper = mapper;
        }
        public string List(ProductSearchCriteriaDTO model)
        {
            var products = _productManager.Search(model);
            string message =
                $"Showing Products by Name: {model.Name ?? "N/A"} Code:{model.Code ?? "N/A"} From Price:{model.FromSalesPrice} To Price: {model.ToSalesPrice} \n";

            if (products != null && products.Any())
            {
                foreach (var product in products)
                {
                    message += $"Name: {product.Name} Code: {product.Code} Price: {product.Price} \n";
                }
            }
            else
            {
                message = "No Product found!";
            }

            return message;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Welcome To Index Page";
            //data loaded code 
            var products = _productManager.GetAll();
            return View(products);
        }

       
        public IActionResult Create()
        {
            var shops = _shopManager.GetAll();

            ICollection<SelectListItem> items = shops.Select(c=> new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            ViewBag.Shops = items;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateVM model)
        {
            if (ModelState.IsValid)
            {

                var product = _mapper.Map<Product>(model);

               bool isSaved =  _productManager.Add(product);               
                if (isSaved)
                {
                   return RedirectToAction("Index");
                }
               
            }

            return View();

        }

        public IActionResult ProductView()
        {
            var shops = _shopManager.GetAll();

            ICollection<SelectListItem> items = shops.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            ViewBag.Shops = items;

            return View();
        }
        
        public IActionResult GetProductByShopId(int shopId)
        {
            var products = _productManager.GetByShopId(shopId);
            return Json(products);
        }

        public IActionResult GetProductById(int productId)
        {
            var product = _productManager.GetById(productId);

            return Json(product);
        }

        
    }
}