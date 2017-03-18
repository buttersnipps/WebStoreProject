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
            Products = new List<Product_vm>();
            BeginDate = new DateTime();
            EndDate = new DateTime();
        }

        [Key]
        public int PromotionId { get; set; }

        [Display(Name = "Percentage Off")]
        public decimal PercentageOff { get; set; }

        [Display(Name = "Sale")]
        public string PromotionName { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        //Association
        public int[] ProductIds { get; set; }
        public IEnumerable<Product_vm> Products { get; set; }
    }

    public class PromotionAddForm 
    {
        public PromotionAddForm()
        {
            Products = new List<Product_vm>();
            BeginDate = new DateTime();
            EndDate = new DateTime();
        }

        [Key]
        public int PromotionId { get; set; }

        [Display(Name = "Percentage Off")]
        public decimal PercentageOff { get; set; }

        [Display(Name = "Sale")]
        public string PromotionName { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        //Association
        public int[] ProductIds { get; set; }
        public List<Product_vm> Products { get; set; }
        public IEnumerable<Product_vm> ProductsEnumerable { get; set; }
    }

    public class PromotionDeleteForm
    {
        public PromotionDeleteForm()
        {
            Products = new List<Product_vm>();
            BeginDate = new DateTime();
            EndDate = new DateTime();
        }

        [Key]
        public int PromotionId { get; set; }

        [Display(Name = "Percentage Off")]
        public decimal PercentageOff { get; set; }

        [Display(Name = "Sale")]
        public string PromotionName { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        //Association
        public int[] ProductIds { get; set; }
        public List<Product_vm> Products { get; set; }
        public IEnumerable<Product_vm> ProductsEnumerable { get; set; }
    }

    public class PromotionEditForm
    {
        public PromotionEditForm()
        {
            Products = new List<Product_vm>();
            BeginDate = new DateTime();
            EndDate = new DateTime();
        }

        [Key]
        public int PromotionId { get; set; }

        [Display(Name = "Percentage Off")]
        public decimal PercentageOff { get; set; }

        [Display(Name = "Sale")]
        public string PromotionName { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        //Association
        public List<Product_vm> Products { get; set; }
        public IEnumerable<Product_vm> ProductsEnumerable { get; set; }
        public int ProductIdToEdit { get; set; }

    }

    public class PromotionDetailsPage
    {
        public PromotionDetailsPage()
        {
            Products = new List<Product_vm>();
            BeginDate = new DateTime();
            EndDate = new DateTime();
        }

        [Key]
        public int PromotionId { get; set; }

        [Display(Name = "Percentage Off")]
        public decimal PercentageOff { get; set; }

        [Display(Name = "Sale")]
        public string PromotionName { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        //Association
        public List<Product_vm> Products { get; set; }

    }
}