using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class SalesReportController : Controller
    {
        private Manager manager = new Manager();
        // GET: SalesReport
        public ActionResult Index()
        {
            return View(manager.SalesReportGetAll());
        }

        // GET: SalesReport/Details/5
        public ActionResult Details(int id)
        {
            return View(manager.SalesReportGetOne(id));
        }
        // GET: SalesReport/Create
        public ActionResult Create()
        {
            var form = new SalesReportAdd();
            form.Month = DateTime.Today;
            return View(form);
        }

        // POST: SalesReport/Create
        [HttpPost]
        public ActionResult Create(SalesReportAdd newItem)
        {
            try
            {
                // Insert new information
                SalesReport_vm Item = AutoMapper.Mapper.Map<SalesReport_vm>(newItem);
                manager.SalesReportAdd(Item);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
