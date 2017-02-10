using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }

    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        public string CountryName { get; set; }
        public City city { get; set; } //Need To make ICollection
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

        public float promotionPrice { get; set; }

    }

    public class Product
    {
        [Key]
        public int productId { get; set; }
        [Display(Name = "Product Name")]
        public string productName { get; set; }
        [Display(Name = "Product Price")]
        public double productPrice { get; set; }
        [Display(Name = "Product Description")]
        public string productDescription { get; set; }
        [Display(Name = "Product Discount")]
        public Promotion productPromo { get; set; }

        public string productImage { get; set; }
        //public string FilePath { get; set; }

        [Display(Name = "Product Weight")]
        public double productWeight { get; set; }
        [Display(Name = "Product Length")]
        public double productLenght { get; set; }
        [Display(Name = "Product Breath")]
        public double productBreath { get; set; }
        [Display(Name = "Product Height")]
        public double productHeight { get; set; }

        [Required]
        public virtual Category Category { get; set; }

    }

    public class Category
    {

        public Category()
        {
            Products = new List<Product>();
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
