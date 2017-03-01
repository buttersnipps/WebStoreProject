using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class OrderCheckBoxViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }
        public int Quantity { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public bool Checked { get; set; }


    }
}