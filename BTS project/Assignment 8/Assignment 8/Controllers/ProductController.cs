using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Assignment_8.Models;
using PagedList;

namespace Assignment_8.Controllers
{
    public class ProductController : Controller
    {

        private ApplicationDbContext ds = new ApplicationDbContext();
        private Manager manage = new Manager();
        // GET: Product
        public ActionResult Index()
        {
            return View(manage.ProductGetAllIEnumerable());
        }

        // Get the product list for the customer side
        public ActionResult Customer_Product_Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = sortOrder =="Name"? "name_desc" : "name_ascend";
            ViewBag.PriceSortParam = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            // var a = ds.Product.OrderBy(p => p.productName).ToList();
            var a = from prod in ds.Products
                    select prod;
            if (!String.IsNullOrEmpty(searchString))
            {
                a = a.Where(prod => prod.ProductName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    a = a.OrderByDescending(prod => prod.ProductName);
                    break;
                case "Price":
                    a = a.OrderBy(prod => prod.ProductPrice);
                    break;
                case "price_desc":
                    a = a.OrderByDescending(prod => prod.ProductPrice);
                    break;
                case "name_ascend":
                    a = a.OrderBy(prod => prod.ProductName);
                    break;
                default:
                    a = a.OrderBy(prod => prod.ProductName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(a.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var o = manage.ProductGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Pass the object to the view
                return View(o);
            }
        }

        public ActionResult DetailsBackEnd(int ? id)
        {
            // Attempt to get the matching object
            var o = manage.ProductGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Pass the object to the view
                return View(o);
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(ds.Categorys, "Id", "Name");
            var productForm = new Product_vm();
            productForm.Promotions = manage.PromotionGetAllList();
            return View(productForm);
        }

        // POST : Product Create 

         [HttpPost ValidateInput(false)]
        public ActionResult Create(Product_vm newItem, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                newItem.Promotions = manage.PromotionGetAllList();
                return View(newItem);
            }

            ViewBag.CategoryId = new SelectList(ds.Categorys, "Id", "Name", newItem.CategoryId);
            var path = "";
            if(file != null)
            {
                if(file.ContentLength > 0)
                {
                    //Check if upload file is image or not
                    if(Path.GetExtension(file.FileName).ToLower() == ".jpg"||
                        Path.GetExtension(file.FileName).ToLower() == ".png"||
                        Path.GetExtension(file.FileName).ToLower() == ".gif" ||
                        Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Content/Image"), file.FileName);
                        file.SaveAs(path);
                        newItem.ProductImage = file.FileName;
                    }
                }
            }else
            {
                var productForm = new Product_vm();
                productForm.Promotions = manage.PromotionGetAllList();
                return View(productForm);
            }

            var addedItem = manage.ProductAdd(newItem);
            if (addedItem == null)
            {
                newItem.Promotions = manage.PromotionGetAllList();
                return View(newItem);
            }
            else
            {
                return RedirectToAction("detailsBackEnd", new { id = addedItem.ProductId });
            }
        }

        public ActionResult Edit(int id)
        {
            var editForm = manage.ProductGetById(id);
            ViewBag.CategoryId = new SelectList(ds.Categorys, "Id", "Name", editForm.CategoryId);

            if (editForm == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(manage.ProductGetById(id));
            }
        }

         [HttpPost ValidateInput(false)]
        public ActionResult Edit(int id, Product_vm newItem, HttpPostedFileBase file)
        {
            var path = "";
            var product = manage.ProductGetById(newItem.ProductId);
            ViewBag.CategoryId = new SelectList(ds.Categorys, "Id", "Name", newItem.CategoryId);
            string fullPath = "";
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    //Check if upload file is image or not
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg" ||
                        Path.GetExtension(file.FileName).ToLower() == ".png" ||
                        Path.GetExtension(file.FileName).ToLower() == ".gif" ||
                        Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        fullPath = Request.MapPath("~/Content/Image/" + product.ProductImage);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        path = Path.Combine(Server.MapPath("~/Content/Image"), file.FileName);
                        file.SaveAs(path);
                        newItem.ProductImage = file.FileName;
                    }
                }
            }

            if (!ModelState.IsValid)
            {
               
                return RedirectToAction("edit", new { id = newItem.ProductId });
            }

            if (id != newItem.ProductId)
            {
           
                return RedirectToAction("index");
            }

    
            var editedItem = manage.ProductEdit(newItem);

            if (editedItem == null)
            {
              
                return RedirectToAction("edit", new { id = newItem.ProductId });
            }
            else
            {
               
                return RedirectToAction("detailsBackEnd", new { id = newItem.ProductId });
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            var itemToDelete = manage.ProductGetById(id.GetValueOrDefault());

            if (itemToDelete == null)
            {
                // Don't leak info about the delete attempt
                // Simply redirect
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = manage.ProductDelete(id.GetValueOrDefault());

            // "result" will be true or false
            // We probably won't do much with the result, because 
            // we don't want to leak info about the delete attempt

            // In the end, we should just redirect to the list view
            return RedirectToAction("index");
        }
    }


}
