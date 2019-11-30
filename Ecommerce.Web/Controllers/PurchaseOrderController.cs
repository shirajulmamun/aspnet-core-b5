using Ecommerce.Library.Entity_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Controllers
{
    public class PurchaseOrderController:Controller
    {
        public IActionResult Create(PurchaseOrder model)
        {
            return View();
        }
    }
}
