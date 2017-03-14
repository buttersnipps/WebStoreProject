using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment_8.Models
{
    public class SalesReport
    {
        [Key]
        public int SalesReportId { get; set; }
        public string SalesReportName { get; set; }
        public DateTime Month { get; set; }
        public ICollection<int> OrderId { get; set; }
        public IEnumerable<Orders> Orders { get; set; }
    }
}