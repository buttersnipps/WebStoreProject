using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class CategoryController : Controller
    {
        Manager manage = new Manager();
        // GET: Category
        public ActionResult Index()
        {
            return View(manage.CategoryGetAll());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View(manage.CategoryGetById(id));
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View(new Category_vm());
        }

        [Route("category/{id}/product")]
        public ActionResult AddProduct(int? id)
        {
            var a = manage.CategoryGetById(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                var o = new Product_vm();
                o.CategoryId = a.Id;
                o.CategoryName = a.Name;

                return View(o);
            }
        }

        [Route("category/{id}/product")]
        [HttpPost]
        public ActionResult AddProduct(Product_vm newItem)
        {
            if(!ModelState.IsValid)
            {
                return View(newItem);
            }

            var addedItem = manage.ProductAdd(newItem);

            if(addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", "products", new { id = addedItem.productId });
            }
        }

         

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category_vm collection)
        {
            try
            {
                // TODO: Add insert logic here

                manage.CategoryAdd(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View(manage.CategoryGetById(id));
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category_vm collection)
        {
            try
            {
                // TODO: Add update logic here
                manage.CategoryUpdate(id, collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View(manage.CategoryGetById(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category_vm collection)
        {
            try
            {
                // TODO: Add delete logic here
                manage.CategoryDelete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
