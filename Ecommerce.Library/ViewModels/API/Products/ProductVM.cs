using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Library.ViewModels.API.Products
{
  
    public class ProductVM
    {
        public ProductVM()
        {
            Dokan = new DokanVM();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string WarehouseLocation { get; set; }
        public double Price { get; set; }
        public DokanVM Dokan { get; set; }


    }



    public class DokanVM
    {
        public int? DokanId { get; set; }
        public string DokanName { get; set; }
    }
}
