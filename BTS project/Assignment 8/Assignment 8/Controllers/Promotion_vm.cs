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
        Manager manager = new Manager();
        public Promotion_vm()
        {
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
    }

    public class PromotionAddForm : Promotion_vm
    {

        public SelectList ProductList { get; set; }
    }
}