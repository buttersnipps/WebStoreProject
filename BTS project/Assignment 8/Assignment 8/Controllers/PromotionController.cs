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
            var promo = manager.PromotionGetOne(id);
            promo.Products = manager.ProductWithPromotion(id);
            return View(promo);
        }

        // GET: Promotion/Create
        public ActionResult Create()
        {
            var temp = new Promotion_vm();
            var form = new PromotionAddForm();
            form.ProductList = new SelectList(manager.ProductGetAll(), "ProductId", "ProductName");
            return View(form);
        }

        // POST: Promotion/Create
        [HttpPost]
        public ActionResult Create(Promotion_vm newItem, FormCollection collection)
        {
            try
            {
                collection.Remove("__RequestVerificationToken");
                collection.Remove("PercentageOff");
                collection.Remove("PromotionName");
                collection.Remove("BeginDate");
                collection.Remove("EndDate");

                ICollection<string> productNames = new List<string>();
                foreach(var key in collection.AllKeys)
                {
                    productNames.Add(collection[key]);
                    collection.Remove(collection[key]);
                }
                var a = manager.PromotionAdd(newItem, productNames);
                return RedirectToAction("Index");
            }
            catch
            {
                var form = new PromotionAddForm();
                form.ProductList = new SelectList(manager.ProductGetAll(), "ProductId", "ProductName");
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
