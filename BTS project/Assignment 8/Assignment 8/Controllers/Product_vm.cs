using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class Category_vm
    {
        public Category_vm()
        {
            Products = new List<Product_vm>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

       
        public IEnumerable<Product_vm> Products { get; set; }
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
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        public SelectList CategoryList { get; set; }
        public string CategoryName { get; set; }


    }


}