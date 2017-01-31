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
        //Manage Category
       public IEnumerable<Category_vm> CategoryGetAll(){
            var r = ds.Categories;
            return Mapper.Map<IEnumerable<Category_vm>>(r);
        }
        public Category_vm CategoryAdd(Category_vm newItem)
        {
            var c = ds.Categories.Add(Mapper.Map<Category>(newItem));
            ds.SaveChanges();
            return (c == null) ? null : Mapper.Map<Category_vm>(c);
        }
        public Category_vm CategoryUpdate(int Id, Category_vm updateItem)
        {
            var c = ds.Categories.Find(Id);
            c.Name = updateItem.Name;
            ds.SaveChanges();

            return (c == null) ? null : Mapper.Map<Category_vm>(c);
        }
        public Category_vm CategoryGetById(int Id)
        {
            var c = ds.Categories.Find(Id);

            return (c == null) ? null : Mapper.Map<Category_vm>(c);
        }
        public Category_vm CategoryDelete(int Id)
        {
            var c = ds.Categories.Find(Id);
            if (c != null)
            {
                ds.Categories.Remove(c);
                ds.SaveChanges();
            }
            return (c == null) ? null : Mapper.Map<Category_vm>(c);
        }

        //Manage Product
        public IEnumerable<Product_vm> ProductGetAll()
        {
            return Mapper.Map<IEnumerable<Product_vm>>(ds.Product);
        }

        public Product_vm ProductGetById(int id)
        {
            var o = ds.Product.Find(id);

            // Return the result, or null if not found
            return (o == null) ? null : Mapper.Map<Product_vm>(o);
        }

        public Product_vm ProductAdd(Product_vm newItem)
        {
            var addedItem = ds.Product.Add(Mapper.Map<Product>(newItem));
            ds.SaveChanges();

            // If successful, return the added item, mapped to a view model object
            return (addedItem == null) ? null : Mapper.Map<Product_vm>(addedItem);
        }

        public Product_vm ProductEdit(Product_vm newItem )
        {
            var o = ds.Product.Find(newItem.productId);

            if(o == null)
            {
                return null;
            }
            else
            {
                ds.Entry(o).CurrentValues.SetValues(newItem);
                ds.SaveChanges();

                return Mapper.Map<Product_vm>(o);
            }
        }

        public bool ProductDelete(int id)
        {
            var itemToDelete = ds.Product.Find(id);

            if (itemToDelete == null)
            {
                return false;
            }
            else
            {
                // Remove the object
                ds.Product.Remove(itemToDelete);
                ds.SaveChanges();

                return true;
            }

        }
        //Track
        /* public IEnumerable<TrackBase> TrackGetAll()
        {
            return Mapper.Map<IEnumerable<TrackBase>>(ds.Tracks);
        }
        public TrackBase TrackGetById(int id)
        {
            var o = ds.Tracks.Find(id);

            return (o == null) ? null : Mapper.Map<TrackBase>(o);
        }
        public TrackBase TrackAdd(TrackAdd newItem, int Id)
        {
            var a = ds.Genres.Find(Id);
            newItem.Genre = a.Name;
            var o = ds.Tracks.Add(Mapper.Map<Track>(newItem));
            byte[] Audios = new byte[newItem.AudioUpload.ContentLength];
            newItem.AudioUpload.InputStream.Read(Audios, 0, newItem.AudioUpload.ContentLength);
            o.Audio = Audios;
            o.AudioType = newItem.AudioUpload.ContentType;
            ds.SaveChanges();
            
            return Mapper.Map<TrackBase>(o);
        }
        //Artist
        public IEnumerable<ArtistBase> ArtistGetAll()
        {
            return Mapper.Map<IEnumerable<ArtistBase>>(ds.Artists);
        }
        public ArtistBase ArtistGetById(int id)
        {
            var o = ds.Artists.Find(id);

            return (o == null) ? null : Mapper.Map<ArtistBase>(o);
        }
        public ArtistBase ArtistAdd(ArtistAdd newItem, int Id)
        {
            var a = ds.Genres.Find(Id);
            newItem.Genre = a.Name;
            var o = ds.Artists.Add(Mapper.Map<Artist>(newItem));
            ds.SaveChanges();
            return (o == null) ? null : Mapper.Map<ArtistBase>(o);
        }
        //Album
        public IEnumerable<AlbumBase> AlbumGetAll()
        {
            return Mapper.Map<IEnumerable<AlbumBase>>(ds.Albums);
        }

        public AlbumBase AlbumGetById(int id)
        {
            var o = ds.Albums.Find(id);

            return (o == null) ? null : Mapper.Map<AlbumBase>(o);
        }

        public AlbumEditForm AlbumGetByIdEditForm(int id)
        {
            var o = ds.Albums.Find(id);

            return (o == null) ? null : Mapper.Map<AlbumEditForm>(o);
        }

        public IEnumerable<TrackBase> SelectedTracks(int id)
        {
            var o = ds.Albums.Find(id);
            
            return Mapper.Map<IEnumerable<TrackBase>>(o.Tracks);
        }

        public AlbumBase AlbumEdit(AlbumEdit editItem)
        {
            var o = ds.Albums.Find(editItem.Id);
            //var t = ds.Tracks.Find(editItem.Trac)
            //ds.Albums.
            o.Name = editItem.Name;
            o.Genre = editItem.Genre;

            foreach(var item in o.Artists)
            {
                o.Artists.Remove(item);
            }
            

            foreach(var item in o.Artists)
            {
               
                o.Artists.Add(Mapper.Map<Artist>(item));
            }

            o.Coordinator = editItem.Coordinator;
            o.Description = editItem.Description;
            o.ReleaseDate = editItem.ReleaseDate;

            o.Tracks.Clear();

            foreach (var item in editItem.TrackId)
            {
                var a = ds.Tracks.Find(item);
                o.Tracks.Add(Mapper.Map<Track>(a));

                //ds.SaveChanges();
            }

            o.UrlAlbum = editItem.UrlAlbum;

            ds.SaveChanges();
            return Mapper.Map<AlbumBase>(editItem);
        }

        public AlbumBase AlbumAdd(AlbumAdd newItem, int Id)
        {
            var a = ds.Genres.Find(Id);
            newItem.Genre = a.Name;
            var o = ds.Albums.Add(Mapper.Map < Album > (newItem));
            ds.SaveChanges();

            return Mapper.Map<AlbumBase>(o);
        }*/
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

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()

       public List<string> RoleClaimGetAllStrings()
        {
            List<string> temp = new List<string>();

            foreach(var item in ds.Role.OrderBy(n => n.Id))
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

        // Add some programmatically-generated objects to the data store
        // Can write one method, or many methods - your decision
        // The important idea is that you check for existing data first
        // Call this method from a controller action/method

       /* public bool LoadData()
        {
            // User name
            var user = HttpContext.Current.User.Identity.Name;

            // Monitor the progress
            bool done = false;

            // ############################################################
            // Genre

            if (ds.Genres.Count() == 0)
            {
                // Add genres

                ds.Genres.Add(new Genre { Name = "Alternative" });
                ds.Genres.Add(new Genre { Name = "Classical" });
                ds.Genres.Add(new Genre { Name = "Country" });
                ds.Genres.Add(new Genre { Name = "Easy Listening" });
                ds.Genres.Add(new Genre { Name = "Hip-Hop/Rap" });
                ds.Genres.Add(new Genre { Name = "Jazz" });
                ds.Genres.Add(new Genre { Name = "Pop" });
                ds.Genres.Add(new Genre { Name = "R&B" });
                ds.Genres.Add(new Genre { Name = "Rock" });
                ds.Genres.Add(new Genre { Name = "Soundtrack" });

                ds.SaveChanges();
                done = true;
            }

            // ############################################################
            // Artist

            if (ds.Artists.Count() == 0)
            {
                // Add artists

                ds.Artists.Add(new Artist
                {
                    Name = "The Beatles",
                    BirthOrStartDate = new DateTime(1962, 8, 15),
                    Executive = user,
                    Genre = "Pop",
                    UrlArtist = "https://upload.wikimedia.org/wikipedia/commons/9/9f/Beatles_ad_1965_just_the_beatles_crop.jpg"
                });

                ds.Artists.Add(new Artist
                {
                    Name = "Adele",
                    BirthName = "Adele Adkins",
                    BirthOrStartDate = new DateTime(1988, 5, 5),
                    Executive = user,
                    Genre = "Pop",
                    UrlArtist = "http://www.billboard.com/files/styles/article_main_image/public/media/Adele-2015-close-up-XL_Columbia-billboard-650.jpg"
                });

                ds.Artists.Add(new Artist
                {
                    Name = "Bryan Adams",
                    BirthOrStartDate = new DateTime(1959, 11, 5),
                    Executive = user,
                    Genre = "Rock",
                    UrlArtist = "https://upload.wikimedia.org/wikipedia/commons/7/7e/Bryan_Adams_Hamburg_MG_0631_flickr.jpg"
                });

                ds.SaveChanges();
                done = true;
            }

            // ############################################################
            // Album

            if (ds.Albums.Count() == 0)
            {
                // Add albums

                // For Bryan Adams
                var bryan = ds.Artists.SingleOrDefault(a => a.Name == "Bryan Adams");

                ds.Albums.Add(new Album
                {
                    Artists = new List<Artist> { bryan },
                    Name = "Reckless",
                    ReleaseDate = new DateTime(1984, 11, 5),
                    Coordinator = user,
                    Genre = "Rock",
                    UrlAlbum = "https://upload.wikimedia.org/wikipedia/en/5/56/Bryan_Adams_-_Reckless.jpg"
                });

                ds.Albums.Add(new Album
                {
                    Artists = new List<Artist> { bryan },
                    Name = "So Far So Good",
                    ReleaseDate = new DateTime(1993, 11, 2),
                    Coordinator = user,
                    Genre = "Rock",
                    UrlAlbum = "https://upload.wikimedia.org/wikipedia/pt/a/ab/So_Far_so_Good_capa.jpg"
                });

                ds.SaveChanges();
                done = true;
            }

            // ############################################################
            // Track

            if (ds.Tracks.Count() == 0)
            {
                // Add tracks

                // For Reckless
                var reck = ds.Albums.SingleOrDefault(a => a.Name == "Reckless");

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { reck },
                    Name = "Run To You",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { reck },
                    Name = "Heaven",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { reck },
                    Name = "Somebody",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { reck },
                    Name = "Summer of '69",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { reck },
                    Name = "Kids Wanna Rock",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                // For Reckless
                var so = ds.Albums.SingleOrDefault(a => a.Name == "So Far So Good");

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { so },
                    Name = "Straight from the Heart",
                    Composers = "Bryan Adams, Eric Kagna",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { so },
                    Name = "It's Only Love",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { so },
                    Name = "This Time",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { so },
                    Name = "(Everything I Do) I Do It for You",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { so },
                    Name = "Heat of the Night",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.SaveChanges();

                done = true;
            }

            if (ds.Role.Count() == 0)
            {
                ds.Role.Add(new RoleClaim
                {
                    Name = "Executive"
                });

                ds.Role.Add(new RoleClaim
                {
                    Name = "Coordinator"
                });

                ds.Role.Add(new RoleClaim
                {
                    Name = "Clerk"
                });

                ds.Role.Add(new RoleClaim
                {
                    Name = "Staff"
                });

                ds.Role.Add(new RoleClaim
                {
                    Name = "Sales Rep"
                });

                ds.Role.Add(new RoleClaim
                {
                    Name = "Secretary"
                });

                ds.SaveChanges();
                done = true;
            }
            return done;
        }
        public bool RemoveData()
        {
            try
            {
                foreach (var e in ds.Tracks)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                foreach (var e in ds.Albums)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                foreach (var e in ds.Artists)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                foreach (var e in ds.Genres)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }*/

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