using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<OrderToProducts> OrdersToProducts { get; set; }

    }
}