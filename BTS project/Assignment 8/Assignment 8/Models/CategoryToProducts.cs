using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class CategoryToProducts
    {
        [Key]
        public int CategoryToProductID { get; set; }
        public int CategoryID { get; set; }
        public int ProductID { get; set; }
        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}