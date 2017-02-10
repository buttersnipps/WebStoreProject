using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace Assignment_8.Controllers
{
    public class ProductController : Controller
    {
        private Manager manage = new Manager();
        // GET: Product
        public ActionResult Index()
        {
            return View(manage.ProductGetAll());
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
        // GET: Product/Create
        public ActionResult Create()
        {
            // At your option, create and send an object to the view
            return View();
        }

        // POST : Product Create 

         [HttpPost ValidateInput(false)]
        public ActionResult Create(Product_vm newItem, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

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
                        newItem.productImage = file.FileName;
                    }
                }
            }
            var addedItem = manage.ProductAdd(newItem);
            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.productId });
            }
        }

        public ActionResult Edit(int id)
        {
            var editForm = manage.ProductGetById(id);

            if(editForm == null)
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
            var product = manage.ProductGetById(newItem.productId);
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
                        fullPath = Request.MapPath("~/Content/Image/" + product.productImage);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        path = Path.Combine(Server.MapPath("~/Content/Image"), file.FileName);
                        file.SaveAs(path);
                        newItem.productImage = file.FileName;
                    }
                }
            }

            if (!ModelState.IsValid)
            {
               
                return RedirectToAction("edit", new { id = newItem.productId });
            }

            if (id != newItem.productId)
            {
           
                return RedirectToAction("index");
            }

    
            var editedItem = manage.ProductEdit(newItem);

            if (editedItem == null)
            {
              
                return RedirectToAction("edit", new { id = newItem.productId });
            }
            else
            {
               
                return RedirectToAction("details", new { id = newItem.productId });
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
