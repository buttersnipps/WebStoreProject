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
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

    }

    public class Product_vm
    {
        [Key]
        public int productId { get; set; }

        [Display(Name = "Name")]
        public string productName { get; set; }

        [Display(Name = "Price")]
        public double productPrice { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string productDescription { get; set; }

        [Display(Name = "Sale")]
        public Promotion_vm productPromo { get; set; }

        [Display(Name = "Quantity")]
        public int quantity { get; set; }

        [Display(Name = "Image")]
        public string productImage { get; set; }

        [Display(Name = "Weight (lb)")]
        public double productWeight { get; set; }

        [Display(Name = "L")]
        public double productLength { get; set; }

        [Display(Name = "W")]
        public double productBreath { get; set; }

        [Display(Name = "H")]
        public double productHeight { get; set; }
    }
}