using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_8.Models;

namespace Assignment_8.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categorys.ToList());
        }

        // GET: Categories/Details/5
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

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categorys.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
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

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
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
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categorys.Find(id);
            db.Categorys.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
