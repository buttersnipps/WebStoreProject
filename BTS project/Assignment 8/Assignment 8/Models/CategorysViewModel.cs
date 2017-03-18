using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class CategorysViewModel
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public List<CheckBoxViewModel> Products { get; set; }
    }
}