using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace Assignment_8.Models
{
    // Add your design model classes below

    // Follow these rules or conventions:

    // To ease other coding tasks, the name of the 
    //   integer identifier property should be "Id"
    // Collection properties (including navigation properties) 
    //   must be of type ICollection<T>
    // Valid data annotations are pretty much limited to [Required] and [StringLength(n)]
    // Required to-one navigation properties must include the [Required] attribute
    // Do NOT configure scalar properties (e.g. int, double) with the [Required] attribute
    // Initialize DateTime and collection properties in a default constructor

    public class Gender
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }

    public class Address
    {
        public int AddressId { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
    }

    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        public string CountryName { get; set; }
        public IEnumerable<City> city { get; set; }
    }

    public class City
    {
        [Key]
        public int CityId { get; set; }

        public string CityName { get; set; }
    }

    public class RoleClaim
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Promotion
    {
        [Key]
        public int promotionId { get; set; }

        [Display(Name ="Promotion Name")]
        public string promotionName { get; set; }

        [Display(Name ="Promotion Percentage Off")]
        public double percentageOff { get; set; }

        [Display(Name = "Promotion Begin Date")]
        public DateTime BeginDate { get; set; }

        [Display(Name ="Promotion End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name ="Promotion Products")]
        public IEnumerable<Product> products { get; set; }

    }

    public class Product
    {
        [Key]
        public int productId { get; set; }

        [Display(Name = "Product Name")]
        public string productName { get; set; }

        [Display(Name = "Product Manufacturer")]
        public string manufacturer { get; set; }

        [Display(Name ="Product Model")]
        public string model { get; set; }

        [Display(Name ="Product Part#")]
        public string partNumber { get; set; }

        [Display(Name = "Product Price")]
        public double productPrice { get; set; }

        [Display(Name = "Product Description")]
        public string productDescription{ get; set; }

        [Display(Name = "Product Discount")]
        public Promotion productPromo { get; set; }

        [Display(Name ="Product Image")]
        public string productImage { get; set; }

        [Display(Name ="Product Quantity")]
        public int quantity { get; set; }

        [Display(Name = "Automatic Quantity Reload")]
        public int reloadValue { get; set; }

        [Display(Name = "Product Weight")]
        public double productWeight { get; set; }

        [Display(Name = "Product Length")]
        public double productLength { get; set; }

        [Display(Name = "Product Width")]
        public double productWidth { get; set; }

        [Display(Name = "Product Height")]
        public double productHeight { get; set; }
    }

    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
