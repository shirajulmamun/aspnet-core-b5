using System;
using System.Linq;
using EcommerceApp.DatabaseContext;
using EcommerceApp.DTO;
using EcommerceApp.Entity_Models;
using EcommerceApp.Repositories;
using EcommerceApp.Extenstions;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp
{
    class Program
    {
        static void Main(string[] args)
        {

            UnitofWork _unitOfWork = new UnitofWork();


            var searchCriteria = new ProductSearchCriteriaDTO()
            {
                Name = "laptop",
                FromSalesPrice = 1000
            };

            var products = _unitOfWork.ProductRepository.Search(searchCriteria);

            foreach (var product in products)
            {
                Console.WriteLine(GetProductInfo(product));
            }






            

            Console.ReadKey();

        }

        static string GetProductInfo(Product product)
        {
            return
                $"Name: {product.Name} Price: {product.Price} WH Location: {product.WarehouseLocation} Shop Id: {product.Dokan?.Id.ToString() ?? "N/A"} Shop Name:{product.Dokan?.Name ?? "N/A"}";
        }
    }
}
