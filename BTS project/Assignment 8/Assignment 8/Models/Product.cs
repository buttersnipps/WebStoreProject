using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public int ReloadValue { get; set; }
        public double ProductWeight { get; set; }
        public double ProductLength { get; set; }
        public double ProductWidth { get; set; }
        public double ProductHeight { get; set; }

        //Associations
        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; }
        public double PromoPrice { get; set; }
        public ICollection<Category> Categorys { get; set; }
        public Manufacture Manufacture { get; set; }
        public Condition Condition { get; set; }
    }
}