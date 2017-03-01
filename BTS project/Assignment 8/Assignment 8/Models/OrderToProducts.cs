using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class OrderToProducts
    {
        [Key]
        public int OrderToProductID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Product Product { get; set; }

    }
}