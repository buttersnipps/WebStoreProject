using Assignment_8.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string CartId { get; set; }

        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Product product { get; set; }


    }
}