using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Assignment_8.Controllers
{
    public class Category_vm
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class Promotion_vm
    {
        [Key]
        public int promotionId { get; set; }

        public float promotionPrice { get; set; }

    }

    public class Product_vm
    {
        [Key]
        public int productId { get; set; }
        [Display(Name = "Product Name")]
        public string productName { get; set; }
        [Display(Name = "Product Price")]
        public double productPrice { get; set; }
        [Display(Name = "Product Description")]
        public string productDescription { get; set; }
        [Display(Name = "Sale")]
        public Promotion_vm productPromo { get; set; }
     
        public string productImage { get; set; }
        [Display(Name = "Product Weight")]
        public double productWeight { get; set; }
        [Display(Name = "Product Length")]
        public double productLenght { get; set; }
        [Display(Name = "Product Breath")]
        public double productBreath { get; set; }
        [Display(Name = "Product Height")]
        public double productHeight { get; set; }
    }
}