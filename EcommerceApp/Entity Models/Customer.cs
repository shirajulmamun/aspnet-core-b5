using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceApp.Entity_Models
{
    public class Customer
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
