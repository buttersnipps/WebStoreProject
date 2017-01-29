using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class AccountManagerController : Controller
    {

        private Manager m = new Manager();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountManagerController()
        {

        }

        public AccountManagerController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;

        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: AccountManager
        public ActionResult Index()
        {
            return View(m.UsersGetAll());
        }

        // GET: AccountManager/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            // Send the object to the view  
            return View(m.GetUserById(id));

        }

        // GET: AccountManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountManager/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountManager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountManager/Delete/5
        public ActionResult Delete(string id)
        {
            return View(m.GetUserById(id));
        }

        // POST: AccountManager/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                // User stays logged in - need a way to kill the session - unAuth
                // If the user being deleted is user himself
                if (id == System.Web.HttpContext.Current.User.Identity.GetUserId())
                {
                    m.DeleteUser(id);
                }

                m.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
