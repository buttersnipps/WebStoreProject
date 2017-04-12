using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment_8.Models;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Assignment_8.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private ApplicationDbContext ds = new ApplicationDbContext();

        // Declare a property to hold the user account for the current request
        // Can use this property here in the Manager class to control logic and flow
        // Can also use this property in a controller 
        // Can also use this property in a view; for best results, 
        // near the top of the view, add this statement:
        // var userAccount = new ConditionalMenu.Controllers.UserAccount(User as System.Security.Claims.ClaimsPrincipal);
        // Then, you can use "userAccount" anywhere in the view to render content
        public UserAccount UserAccount { get; private set; }
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                // Null coalescing operator

                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public Manager()
        {
            // If necessary, add constructor code here

            // Initialize the UserAccount property
            UserAccount = new UserAccount(HttpContext.Current.User as ClaimsPrincipal);

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }
        /***************************************************************************************************/
        //Manage Category
        public IEnumerable<Category_vm> CategoryGetAll()
        {
            var r = ds.Categorys;
            return Mapper.Map<IEnumerable<Category_vm>>(r);
        }
        public Category_vm CategoryAdd(Category_vm newItem)
        {
            var c = ds.Categorys.Add(Mapper.Map<Category>(newItem));
            ds.SaveChanges();
            return (c == null) ? null : Mapper.Map<Category_vm>(c);
        }
        public Category_vm CategoryUpdate(int Id, Category_vm updateItem)
        {
            var c = ds.Categorys.Find(Id);
            c.Name = updateItem.Name;
            ds.SaveChanges();

            return (c == null) ? null : Mapper.Map<Category_vm>(c);
        }
        public Category_vm CategoryGetById(int Id)
        {
            var c = ds.Categorys.Find(Id);

            return (c == null) ? null : Mapper.Map<Category_vm>(c);
        }
        public Category_vm CategoryDelete(int Id)
        {
            var c = ds.Categorys.Find(Id);
            if (c != null)
            {
                ds.Categorys.Remove(c);
                ds.SaveChanges();
            }
            return (c == null) ? null : Mapper.Map<Category_vm>(c);
        }

        /***************************************************************************************************/
        //Manage Product
        public IEnumerable<Product_vm> ProductGetAllIEnumerable()
        {
            var products = ds.Products.Include("Promotion");

            foreach (var item in products)
            {
                item.PromoPrice = Math.Round(item.PromoPrice, 2);
            }

            return Mapper.Map<IEnumerable<Product_vm>>(products);
        }

        public Product_vm ProductGetById(int id)
        {
            var o = ds.Products.Include("Promotion").SingleOrDefault(temp => temp.ProductId == id);

            // Return the result, or null if not found
            return (o == null) ? null : Mapper.Map<Product_vm>(o);
        }

        public Product_vm ProductAdd(Product_vm newItem)
        {
            var calculator = Mapper.Map<Promotion_vm>(ds.Promotions.Find(newItem.PromotionId));
            newItem.PromoPrice = newItem.ProductPrice - (newItem.ProductPrice * calculator.PercentageOff);
            var addedItem = ds.Products.Add(Mapper.Map<Product>(newItem));
            ds.SaveChanges();

            // If successful, return the added item, mapped to a view model object
            return (addedItem == null) ? null : Mapper.Map<Product_vm>(addedItem);
        }

        public Product_vm ProductEdit(Product_vm newItem)
        {
            var o = ds.Products.Include("Promotion").SingleOrDefault(temp => temp.ProductId == newItem.ProductId);

            if (o == null)
            {
                return null;
            }
            else
            {
                if(newItem.ProductImage != null)
                {
                    o.ProductImage = newItem.ProductImage;
                }

                o.Quantity = newItem.Quantity;
                o.ProductWidth = newItem.ProductWidth;
                o.ProductWeight = newItem.ProductWeight;
                o.ProductPrice = newItem.ProductPrice;
                o.ProductName = newItem.ProductName;
                o.ProductLength = newItem.ProductLength;
                o.ProductHeight = newItem.ProductHeight;
                o.ProductDescription = newItem.ProductDescription;

                ds.SaveChanges();

                return Mapper.Map<Product_vm>(o);
            }
        }

        public bool ProductDelete(int id)
        {
            var itemToDelete = ds.Products.Find(id);

            if (itemToDelete == null)
            {
                return false;
            }
            else
            {
                // Remove the object
                ds.Products.Remove(itemToDelete);
                ds.SaveChanges();

                return true;
            }

        }
        /***************************************************************************************************/
        //Manage Promotions
        public List<Promotion_vm> PromotionGetAllList()
        {
            var all = ds.Promotions;

            return (all == null) ? null : Mapper.Map<List<Promotion_vm>>(all);
        }

        public IEnumerable<Promotion_vm> PromotionGetAll()
        {
            var all = ds.Promotions;

            return (all == null) ? null : Mapper.Map<IEnumerable<Promotion_vm>>(all);
        }

        public Promotion_vm PromotionGetOne(int id)
        {
            var promo = ds.Promotions.Find(id);

            return (promo == null) ? null : Mapper.Map<Promotion_vm>(promo);
        }

        public bool CheckNoneExist()
        {
            var a = ds.Promotions.SingleOrDefault(tmp => tmp.PromotionName == "None");

            return (a == null) ? false : true;
        }
        public bool CheckIfNameDoesNotExist(Promotion_vm item)
        {
            var all = ds.Promotions.SingleOrDefault(temp => temp.PromotionName == item.PromotionName);

            return (all == null) ? true : false; 
        }
        /*Find Promotion For one Product*/
        public IEnumerable<Product_vm> ProductWithPromotion(int id)
        {
            var promo = ds.Promotions.Find(id);
            var product = ds.Products.AsEnumerable().Where(tmp => tmp.PromotionId == id);

            return (product == null) ? null : Mapper.Map<IEnumerable<Product_vm>>(product);
        }

        /*Find All Products With Promotions*/
        public IEnumerable<Product_vm> ProductsWithPromotions()
        {
            var products = ds.Products.Where(temp => temp.Promotion.PromotionName != "None");

            foreach (var item in products)
            {
                item.Promotion = ds.Promotions.SingleOrDefault(temp => temp.PromotionId == item.PromotionId);
            }
            return (products == null) ? null : Mapper.Map<IEnumerable<Product_vm>>(products);
        }

        public List<Product_vm> ProductsWithoutPromotions()
        {
            var products = ds.Products.Where(temp => temp.Promotion.PromotionName == "None");

            return (products == null) ? null : Mapper.Map<List<Product_vm>>(products);
        }

        public Promotion_vm PromotionAdd(Promotion_vm newItem)
        {
            //Make Percentageoff a decimal
            newItem.PercentageOff = newItem.PercentageOff / 100;

            //If productIds is null skip this step or else
            //Find the product with a ProductId same with ProductIds
            //and make its PromotionId the same as newItem
            if (newItem.ProductIds != null)
            {
                foreach (var item in newItem.ProductIds)
                {
                    var product = ds.Products.Single(temp => temp.ProductId == item);
                    product.PromotionId = newItem.PromotionId;
                    product.PromoPrice = product.ProductPrice - (product.ProductPrice * newItem.PercentageOff);
                }
            }

            //Add promotion save changes and return
            ds.Promotions.Add(Mapper.Map<Promotion>(newItem));
            ds.SaveChanges();

            return (newItem == null) ? null : Mapper.Map<Promotion_vm>(newItem);
        }

        public bool PromotionDelete(int id)
        {
            //Find Products that will be affected by the deletion of this 
            //Promotion
            var productsFix = ds.Products.Where(temp => temp.PromotionId == id);

            //Get the default Promotion to set on the products that will be affected
            var none = ds.Promotions.SingleOrDefault(temp => temp.PromotionName == "None");

            //Find the Promotion To be deleted and delete it
            var tmp = ds.Promotions.Find(id);
            ds.Promotions.Remove(tmp);

            //Go through each product and set its promotionId to the default promotion
            foreach (var item in productsFix)
            {
                item.PromotionId = none.PromotionId;
                item.PromoPrice = item.ProductPrice;
            }

            ds.SaveChanges();

            return true;
        }

        public Promotion_vm PromotionEdit(Promotion_vm EditItem, int[] ProductIds)
        {
            //Find Promotion In Database and update values
            var item = ds.Promotions.Find(EditItem.PromotionId);
            ds.Entry(item).CurrentValues.SetValues(EditItem);

            //Set all the PromotionIds to none.PromotionId
            var removePromo = ds.Products.Where(x => x.PromotionId == item.PromotionId);
            var none = ds.Promotions.SingleOrDefault(t => t.PromotionName == "None");
            foreach (var itemToRemovePromo in removePromo)
            {
                itemToRemovePromo.PromotionId = none.PromotionId;
                itemToRemovePromo.PromoPrice = itemToRemovePromo.ProductPrice;
            }

            //Find Product to add to Promotion and 
            //Update PromotionId and PromoPrice
            foreach (var items in ProductIds)
            {
                var products = ds.Products.Find(items);
                products.PromotionId = EditItem.PromotionId;
                products.PromoPrice = products.ProductPrice - (products.ProductPrice * EditItem.PercentageOff);
            }

            ds.SaveChanges();

            return Mapper.Map<Promotion_vm>(item);
        }

        /***************************************************************************************************/
        //Manage SalesReports

        public IEnumerable<SalesReport_vm> SalesReportGetAll()
        {
            var all = ds.SalesReports;

            return (all == null) ? null : Mapper.Map<IEnumerable<SalesReport_vm>>(all);
        }

        public SalesReportDetails SalesReportGetOne(int id)
        {
            var item = ds.SalesReports.Find(id);

            return (item == null) ? null : Mapper.Map<SalesReportDetails>(item);
        }

        public bool addSalesReport(float revenue_)
        {
            var makeDate = DateTime.Now;
            var month = makeDate.Month;
            bool add = false;
            var year = makeDate.Year;
            String date;
            date = month.ToString();
            date += " ";
            date += year.ToString();
            
            //Do checking if item exists
            var item = ds.SalesReports.Where(p => p.SalesReportName == date).SingleOrDefault();

            if(item == null)
            {
                item = new SalesReport();
                item.SalesReportName = date;
                item.Month = DateTime.Now;
                item.Total += revenue_;
                add = true;
            }else
            {
                item.Total += revenue_;
            }

            //Get total amount of Sales reports to see if percentage calculation is needed
            var count = ds.SalesReports.Count();


            if (count > 0)
            {
                var last = ds.SalesReports.OrderByDescending(id => id.SalesReportId).First();

                float revenueChange = item.Total - last.Total;

                float difference = Math.Abs(revenueChange / last.Total);

                if (revenueChange < 0)
                {
                    difference *= -1;
                }

                difference *= 100;

                item.PercentageChange = difference;
            }
            else
            {
                item.PercentageChange = 0;
            }

            if (add)
            {
                ds.SalesReports.Add(item);
            }
            ds.SaveChanges();

            return true;
        }
        public SalesReport_vm SalesReportAdd(SalesReport_vm Item)
        {
            bool doThis = false;
            var count = 0;
            var check = SalesReportGetAll();
            if(check.Count() != 0)
            {
                doThis = true;
            }


            if (doThis)
            {
                count = ds.SalesReports.Count();
            }


            if (count > 0)
            {
                var last = ds.SalesReports.OrderByDescending(id => id.SalesReportId).First();

                float revenueChange = Item.Total - last.Total;

                float difference = Math.Abs(revenueChange / last.Total);

                if (revenueChange < 0)
                {
                    difference *= -1;
                }

                difference *= 100;

                Item.PercentageChange = difference;
            }
            else
            {
                Item.PercentageChange = 0;
            }
            ds.SalesReports.Add(Mapper.Map<SalesReport>(Item));
            ds.SaveChanges();

            return Item;
        }





        public bool RemoveDatab()
        {
            try
            {
                return ds.Database.Delete();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<string> RoleClaimGetAllStrings()
        {
            List<string> temp = new List<string>();

            foreach (var item in ds.Role.OrderBy(n => n.Id))
            {
                temp.Add(item.Name);
            }

            return temp;
        }

        public bool addRole()
        {
            if (ds.Role.Count() == 0)
            {

                ds.Role.Add(new RoleClaim
                {
                    Name = "Executive"
                });
                ds.Role.Add(new RoleClaim
                {
                    Name = "Manager"
                });

                ds.Role.Add(new RoleClaim
                {
                    Name = "Employee"
                });

                ds.Role.Add(new RoleClaim
                {
                    Name = "Customer"
                });
                ds.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveDatabase()
        {
            try
            {
                return ds.Database.Delete();
            }
            catch (Exception)
            {
                return false;
            }
        }


        // Account Related functions

        // Get All Users
        public IEnumerable<ApplicationUserBase> UsersGetAll()
        {
            // Fetch all users        
            var allUsers = UserManager.Users;

            if (allUsers == null)
            {
                return null;
            }

            var userList = new List<ApplicationUserBase>();
            foreach (var user in allUsers)
            {
                // Map the values all users to view model
                var appUser = Mapper.Map<ApplicationUserBase>(user);
                var userClaims = user.Claims.Where
                     (c => c.ClaimType == ClaimTypes.Role).Select(roles => roles.ClaimValue).ToArray();

                // Add Role Claims
                appUser.Roles = userClaims;
                userList.Add(appUser);
            }
            return userList;
        }

        // Get User by Id
        public ApplicationUserDetail GetUserById(string id)
        {
            // Fetch the User by Id
            var user = UserManager.FindById(id);

            if (user == null)
            {
                return null;
            }

            // Initialize UserAccount
            var userIdentity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie) as ClaimsIdentity;
            var claimsPrincipal = new ClaimsPrincipal(userIdentity);

            var userAccount = new UserAccount(claimsPrincipal);

            // Map user details
            var details = Mapper.Map<ApplicationUserDetail>(userAccount);
            details.UserName = user.UserName;
            details.Email = user.UserName;
            details.Roles = userAccount.RoleClaims;

            return details;
        }

        // Delete User
        public void DeleteUser(string id)
        {
            var user = UserManager.FindById(id);

            // Initialize UserAccount
            var userIdentity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie) as ClaimsIdentity;
            var claimsPrincipal = new ClaimsPrincipal(userIdentity);

            var userAccount = new UserAccount(claimsPrincipal);

            // Get all claims
            var claims = claimsPrincipal.Claims;
            // Set a flag for successful remove
            var check = true;
            // Remove all claims from user
            foreach (var claim in claims)
            {
                var r = UserManager.RemoveClaimAsync(user.Id, new Claim(claim.Type, claim.Value)).Result;
                if (!r.Succeeded) { check = false; }
            }

            // Finally remove the user
            if (check)
            {
                var result = UserManager.DeleteAsync(user).Result;
            }
        }


    }

    // New "UserAccount" class for the authenticated user
    // Includes many convenient members to make it easier to render user account info
    // Study the properties and methods, and think about how you could use it
    public class UserAccount
    {
        // Constructor, pass in the security principal
        public UserAccount(ClaimsPrincipal user)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                Principal = user;

                // Extract the role claims
                RoleClaims = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

                // User name
                Name = user.Identity.Name;

                // Extract the given name(s); if null or empty, then set an initial value
                string gn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.GivenName).Value;
                if (string.IsNullOrEmpty(gn)) { gn = "(empty given name)"; }
                GivenName = gn;

                // Extract the surname; if null or empty, then set an initial value
                string sn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Surname).Value;
                if (string.IsNullOrEmpty(sn)) { sn = "(empty surname)"; }
                Surname = sn;

                IsAuthenticated = true;
                IsAdmin = user.HasClaim(ClaimTypes.Role, "Admin") ? true : false;
            }
            else
            {
                RoleClaims = new List<string>();
                Name = "anonymous";
                GivenName = "Unauthenticated";
                Surname = "Anonymous";
                IsAuthenticated = false;
                IsAdmin = false;
            }

            NamesFirstLast = $"{GivenName} {Surname}";
            NamesLastFirst = $"{Surname}, {GivenName}";
        }

        // Public properties
        public ClaimsPrincipal Principal { get; private set; }
        public IEnumerable<string> RoleClaims { get; private set; }

        public string Name { get; set; }

        public string GivenName { get; private set; }
        public string Surname { get; private set; }

        public string NamesFirstLast { get; private set; }
        public string NamesLastFirst { get; private set; }

        public bool IsAuthenticated { get; private set; }

        // Add other role-checking properties here as needed
        public bool IsAdmin { get; private set; }

        public bool HasRoleClaim(string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(ClaimTypes.Role, value) ? true : false;
        }

        public bool HasClaim(string type, string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(type, value) ? true : false;
        }
    }

}