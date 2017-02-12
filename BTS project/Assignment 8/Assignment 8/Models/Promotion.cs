using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class Promotion
    {
        public Promotion()
        {
            Products = new List<Product>();
        }
        [Key]
        public int PromotionId { get; set; }
        public string PromotionName { get; set; }
        public double PercentageOff { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set;}
        public virtual ICollection<Product> Products { get; set; }
    }
}