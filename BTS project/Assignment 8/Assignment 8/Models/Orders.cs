using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class Orders
    {
        [Key]
        public int orderId { get; set; }

        Product currentOrder { get; set; }



    }
}