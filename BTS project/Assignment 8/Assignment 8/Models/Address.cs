using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_8.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
    }
}