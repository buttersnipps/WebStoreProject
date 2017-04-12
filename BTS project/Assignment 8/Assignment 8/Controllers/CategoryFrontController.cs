using Assignment_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class CategoryFrontController : Controller
    {
        // GET: CategoryFront
        private ApplicationDbContext ds = new ApplicationDbContext();
        public ActionResult Index(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = ds.Categorys.Find(id);
            if(category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
    }
}