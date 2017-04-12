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
        public decimal ProductPrice { get; set; }
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
        public decimal PromoPrice { get; set; }
        //public virtual ICollection<CategoryToProducts> CategoryToProducts { get; set; }
        public int CategoryId{get;set;}
        public virtual Category Category { get; set; }
        public Manufacture Manufacture { get; set; }
        public Condition Condition { get; set; }
        public string OrderName { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
       
    }
}