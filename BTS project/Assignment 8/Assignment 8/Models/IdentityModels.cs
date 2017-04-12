using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
// new...
using System.Data.Entity.ModelConfiguration.Conventions;
using System;

namespace Assignment_8.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Added Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender gender { get; set; }
        public Address address { get; set; }
        public DateTime Birthday { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // Add DbSet<TEntity> properties here
        public DbSet<RoleClaim> Role { get; set; }
        public DbSet<Category>Categorys { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<SalesReport> SalesReports { get; set; }



        // Turn OFF cascade delete, which is (unfortunately) the default setting
        // for Code First generated databases
        // For most apps, we do NOT want automatic cascade delete behaviour
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // First, call the base OnModelCreating method,
            // which uses the existing class definitions and conventions

            base.OnModelCreating(modelBuilder);

            // Then, turn off "cascade delete" for 
            // all default convention-based associations

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Assignment_8.Controllers.Product_vm> Product_vm { get; set; }

        public System.Data.Entity.DbSet<Assignment_8.Controllers.ApplicationUserBase> ApplicationUserBases { get; set; }

        public System.Data.Entity.DbSet<Assignment_8.Controllers.Promotion_vm> Promotion_vm { get; set; }

        public System.Data.Entity.DbSet<Assignment_8.Controllers.PromotionAddForm> PromotionAdds { get; set; }

        public System.Data.Entity.DbSet<Assignment_8.Controllers.PromotionDeleteForm> PromotionDeleteForms { get; set; }

        public System.Data.Entity.DbSet<Assignment_8.Controllers.PromotionEditForm> PromotionEditForms { get; set; }

        public System.Data.Entity.DbSet<Assignment_8.Controllers.PromotionDetailsPage> PromotionDetailsPages { get; set; }


        public System.Data.Entity.DbSet<Assignment_8.Controllers.ShoppingCartViewModel> ShoppingCartViewModels { get; set; }

        public System.Data.Entity.DbSet<Assignment_8.Controllers.SalesReport_vm> SalesReport_vm { get; set; }

        public System.Data.Entity.DbSet<Assignment_8.Controllers.SalesReportAdd> SalesReportAdds { get; set; }
    }
}