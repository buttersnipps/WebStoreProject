using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class PromotionController : Controller
    {
        Manager manager = new Manager();
        // GET: Promotion
        public ActionResult Index()
        {
            return View(manager.PromotionGetAll());
        }

        // GET: Promotion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Promotion/Create
        public ActionResult Create()
        {
            var form = new PromotionAddForm();
            form.Products = manager.ProductsWithoutPromotions();
            form.BeginDate = DateTime.Today;
            form.EndDate = DateTime.Today;
            return View(form);
        }

        // POST: Promotion/Create
        [HttpPost]
        public ActionResult Create(Promotion_vm newItem)
        {
            try
            {
                var a = manager.PromotionAdd(newItem);
                return RedirectToAction("Index");
            }
            catch
            {
                var form = new PromotionAddForm();
                form.Products = manager.ProductsWithoutPromotions();
                return View(form);
            }
        }

        // GET: Promotion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Promotion/Edit/5
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

        // GET: Promotion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Promotion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
