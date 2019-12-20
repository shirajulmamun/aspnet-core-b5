using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Models.ViewModels.Web.Product
{
    public class ProductCreateVM
    {
        [Required(ErrorMessage = "Please provide name!")]
        public string Name { get; set; }

        [StringLength(11)]
        public string Code { get; set; }
        public double Price { get; set; }

        public string WarehouseLocation { get; set; }

        public int? DokanId { get; set; }

        [NotMapped]
        public List<Ecommerce.Models.EntityModels.Product> Products { get; set; }
    }
}
