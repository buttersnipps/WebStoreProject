using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Assignment_8.Models;

namespace Assignment_8.Controllers
{
    public class Product_vm
    {
        public Product_vm()
        {
            Promotions = new List<Promotion_vm>();
        }
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        public decimal ProductPrice { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string ProductDescription { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Automatic Quantity Reload")]
        public int ReloadValue { get; set; }

        [Display(Name = "Image")]
        public string ProductImage { get; set; }

        [Display(Name = "Weight (lb)")]
        public double ProductWeight { get; set; }

        [Display(Name = "L")]
        public double ProductLength { get; set; }

        [Display(Name = "W")]
        public double ProductWidth { get; set; }

        [Display(Name = "H")]
        public double ProductHeight { get; set; }

        //Association
        public int PromotionId { get; set; }
        public Promotion_vm Promotion { get; set; }
        [Display(Name ="Promotion Price")]
        public decimal PromoPrice { get; set; }
        public List<Promotion_vm> Promotions { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}