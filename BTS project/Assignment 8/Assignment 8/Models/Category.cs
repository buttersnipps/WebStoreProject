using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class Category
    {
        
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CategoryToProducts> CategoryToProducts { get; set; }
    }
}