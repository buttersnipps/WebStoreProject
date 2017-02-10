using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class LoadDataController : Controller
    {
        // Reference to the manager object
        Manager m = new Manager();

        // GET: LoadData
        public ActionResult Index()
        {
            m.addRole();
            /* if (m.LoadData())
             {
                 return RedirectToAction("../Home/Index");
             }
             else
             {
                 return RedirectToAction("../Home/Index");
             }*/
            return View();
        }

        public ActionResult Remove()
        {
            /*if (m.RemoveData())
            {
                return View("../Home/Index");
            }
            else
            {
                return Content("could not remove data");
            }*/
            return View();
        }

        public ActionResult RemoveDatabase()
        {
            if (m.RemoveDatab())
            {
                return RedirectToAction("../Home");
            }
            else
            {
                return Content("could not remove database");
            }
        }
       

    }
}