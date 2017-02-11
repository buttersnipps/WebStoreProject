using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        [ForeignKey("ProductId")]
        public virtual ICollection<Product> Products { get; set; }
    }
}