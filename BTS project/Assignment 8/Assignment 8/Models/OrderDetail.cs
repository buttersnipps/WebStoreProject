using Assignment_8.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDeatilId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public virtual Product product { get; set; }
        public virtual Order Order { get; set; }
    }
}