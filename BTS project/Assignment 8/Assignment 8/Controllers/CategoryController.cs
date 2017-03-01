using Assignment_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        Manager manage = new Manager();
        // GET: Category
        public ActionResult Index()
        {
            return View(manage.CategoryGetAll());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categorys.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var results = from b in db.Products
                          select new
                          {
                              b.ProductId,
                              b.ProductName,
                              Checked = ((from ab in db.CategoryToProducts
                                          where (ab.CategoryID == id) & (ab.ProductID == b.ProductId)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new CategorysViewModel();

            MyViewModel.CategoryID = id.Value;
            MyViewModel.Name = category.Name;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.ProductId, Name = item.ProductName, Checked = item.Checked });
            }

            MyViewModel.Products = MyCheckBoxList;

            return View(MyViewModel);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View(new Category_vm());
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categorys.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var results = from b in db.Products
                          select new
                          {
                              b.ProductId,
                              b.ProductName,
                              Checked = ((from ab in db.CategoryToProducts
                                          where (ab.CategoryID == id) & (ab.ProductID == b.ProductId)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new CategorysViewModel();

            MyViewModel.CategoryID = id.Value;
            MyViewModel.Name = category.Name;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.ProductId, Name = item.ProductName, Checked = item.Checked });
            }

            MyViewModel.Products = MyCheckBoxList;

            return View(MyViewModel);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategorysViewModel Category)
        {
            if (ModelState.IsValid)
            {
                var MyCategory = db.Categorys.Find(Category.CategoryID);

                MyCategory.Name = Category.Name;

                foreach (var item in db.CategoryToProducts)
                {
                    if (item.CategoryID == Category.CategoryID)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in Category.Products)
                {
                    if (item.Checked)
                    {
                        db.CategoryToProducts.Add(new CategoryToProducts() { CategoryID = Category.CategoryID, ProductID = item.Id });
                    }

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Category);
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
