using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_8.Controllers
{

    public class Category_vm
    {
       
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; }
        public IEnumerable<Product_vm> Products { get; set; }
    }
}