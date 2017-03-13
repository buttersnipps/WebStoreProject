using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment_8.Controllers
{
    public class SalesReportBase
    {
        [Key]
        public int SalesReportId { get; set; }
    }
    public class SalesReport_vm
    {
        [Key]
        public int SalesReportId { get; set; }
        [Display(Name ="Sales Report")]
        public string SalesReportName { get; set; }
        [Display(Name ="Month")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        public DateTime Month { get; set; }
        [Display(Name ="Total")]
        public float Total { get; set; }
        [Display(Name ="Percentage Changed")]
        public float PercentageChange { get; set; }
    }

    public class SalesReportAdd : SalesReportBase
    {
        [Display(Name = "Sales Report")]
        public string SalesReportName { get; set; }
        [Display(Name = "Month")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        public DateTime Month { get; set; }
        [Display(Name = "Total")]
        public float Total { get; set; }
    }

    public class SalesReportDetails : SalesReportBase
    {
        [Display(Name = "Sales Report")]
        public string SalesReportName { get; set; }
        [Display(Name = "Month")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        public DateTime Month { get; set; }
        [Display(Name = "Total")]
        public float Total { get; set; }
        [Display(Name = "Percentage Changed")]
        public float PercentageChange { get; set; }
    }
}