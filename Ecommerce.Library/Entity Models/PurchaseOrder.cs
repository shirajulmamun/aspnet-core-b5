﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Library.Entity_Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string RefNo { get; set; }

        public ICollection<PurchaseOrderItem> OrderItems { get; set; }

    }
}
