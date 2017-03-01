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
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Order.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders order = db.Order.Find(id);
            if (order== null)
            {
                return HttpNotFound();
            }

            var results = from b in db.Products
                          select new
                          {
                              b.ProductId,
                              b.ProductName,
                              b.ProductDescription,
                              b.ProductPrice,
                              b.Quantity,
                              b.ProductLength,
                              b.ProductWeight,
                              b.ProductWidth,
                              b.ProductHeight,

                              Checked = ((from ab in db.OrdersToProduct
                                          where (ab.OrderID == id) & (ab.ProductID == b.ProductId)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new OrdersViewModel();

            MyViewModel.OrderID = id.Value;
            MyViewModel.Name = order.Name;

            var MyCheckBoxList = new List<OrderCheckBoxViewModel>();

            foreach (var item in results)
            {

                MyCheckBoxList.Add(new OrderCheckBoxViewModel
                {
                    Id = item.ProductId,
                    Name = item.ProductName,
                    Desc = item.ProductDescription,
                    Price = item.ProductPrice,
                    Quantity = item.Quantity,
                    Height = item.ProductHeight,
                    Length = item.ProductLength,
                    Width = item.ProductWidth,
                    Weight = item.ProductWeight,
                    Checked = item.Checked
                });
            }

            MyViewModel.Products = MyCheckBoxList;

            return View(MyViewModel);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Order.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orders);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            var results = from b in db.Products
                          select new
                          {
                              b.ProductId,
                              b.ProductName,
                              b.ProductDescription,
                              b.ProductPrice,
                              b.Quantity,
                              b.ProductLength,
                              b.ProductWeight,
                              b.ProductWidth,
                              b.ProductHeight,

                              Checked = ((from ab in db.OrdersToProduct
                                          where (ab.OrderID == id) & (ab.ProductID == b.ProductId)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new OrdersViewModel();

            MyViewModel.OrderID = id.Value;
            MyViewModel.Name = order.Name;
            

            var MyCheckBoxList = new List<OrderCheckBoxViewModel>();

            foreach (var item in results)
            {
                
                MyCheckBoxList.Add(new OrderCheckBoxViewModel { Id = item.ProductId, Name = item.ProductName,
                    Desc = item.ProductDescription, Price = item.ProductPrice, Quantity = item.Quantity, Height = item.ProductHeight,
                    Length = item.ProductLength, Width = item.ProductWidth,Weight = item.ProductWeight, Checked = item.Checked });
            }

            MyViewModel.Products = MyCheckBoxList;

            return View(MyViewModel);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdersViewModel Order)
        {
            if (ModelState.IsValid)
            {
                var MyOrder = db.Order.Find(Order.OrderID);

                MyOrder.Name = Order.Name;

                foreach (var item in db.OrdersToProduct)
                {
                    if (item.OrderID == Order.OrderID)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in Order.Products)
                {
                    if (item.Checked)
                    {
                        db.OrdersToProduct.Add(new OrderToProducts() { OrderID = Order.OrderID, ProductID = item.Id });
                    }

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Order.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Order.Find(id);
            db.Order.Remove(orders);
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
