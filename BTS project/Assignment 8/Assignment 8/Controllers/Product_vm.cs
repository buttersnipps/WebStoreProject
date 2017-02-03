using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using Assignment_8.Models;

namespace Assignment_8.Controllers
{
    
    public class Category_vm
    {
        public Category_vm()
        {
            Products = new List<Product>();
        }
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Phone Type")]
        public string Name { get; set; }

        ICollection<Product> Products { get; set; }
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
    public class ProductWithCategory : Product_vm
    {
        [Display(Name = "Product Type")]
        public string ProductCategory { get; set; }
    }

    public class CategoryWithPhones : Category
    {
        public CategoryWithPhones()
        {
            Products = new List<Product>();
        }
        public IEnumerable<Product> Products { get; set; }
    }

}