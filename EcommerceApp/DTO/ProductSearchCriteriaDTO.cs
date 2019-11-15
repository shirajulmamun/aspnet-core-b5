using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceApp.DTO
{
    public class ProductSearchCriteriaDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double FromSalesPrice { get; set; }
        public double ToSalesPrice { get; set; }
    }
}
