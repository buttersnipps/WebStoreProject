using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//Added Namespaces
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class Promotion_vm
    {
        public Promotion_vm()
        {
            Products = new List<Product_vm>();
        }

        [Key]
        public int PromotionId { get; set; }

        [Display(Name = "Percentage Off")]
        public double PercentageOff { get; set; }

        [Display(Name = "Sale")]
        public string PromotionName { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public IEnumerable<Product_vm> Products { get; set; }
    }

    public class PromotionAddForm 
    {
        [Key]
        public int PromotionId { get; set; }

        [Display(Name = "Percentage Off")]
        public double PercentageOff { get; set; }

        [Display(Name = "Sale")]
        public string PromotionName { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public SelectList ProductList { get; set; }
    }
}