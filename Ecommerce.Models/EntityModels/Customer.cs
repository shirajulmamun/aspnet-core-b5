using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Models.EntityModels
{
    public class Customer
    {
        
        public int Id { get; set; } 
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
