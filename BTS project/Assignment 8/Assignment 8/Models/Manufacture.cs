using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class Manufacture
    {
        public int ManufactureId { get; set; }
        public string Name { get; set; }
        public ICollection<Model> ManufactureModel { get; set; }
    }
}