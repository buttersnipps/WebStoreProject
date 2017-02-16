using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class Product
    {
        [Key]
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
        public ICollection<Category> Categorys { get; set; }
        public Manufacture ManufactureId { get; set; }
        public Condition ConditionId { get; set; }

        public int PromotionId { get; set; }
        public virtual Promotion Promotion { get; set; }
   
    }
}