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
            var form = new PromotionDetailsPage();
            form = AutoMapper.Mapper.Map<PromotionDetailsPage>(manager.PromotionGetOne(id));
            form.Products = manager.ProductWithPromotion(id).ToList();

            //Table Headers
            ViewBag.ProductName = "Product Name";
            ViewBag.Discount = "Discount";

            return View(form);
        }

        // GET: Promotion/Create
        public ActionResult Create()
        {
            var form = new PromotionAddForm();
            form.Products = manager.ProductsWithoutPromotions();
            form.BeginDate = DateTime.Today;
            form.EndDate = DateTime.Today;
            form.ProductsEnumerable = manager.ProductsWithPromotions();

            //Table Headers
            ViewBag.ProductName = "Product Name";
            ViewBag.PromotionName = "Promotion Name";
            ViewBag.Discount = "Discount";
            return View(form);
        }

        // POST: Promotion/Create
        [HttpPost]
        public ActionResult Create(Promotion_vm newItem)
        {
            bool check;
            try
            {
                if (newItem.PromotionName == "None") {
                    check = manager.CheckNoneExist();
                    if (check == false) {
                        var a = manager.PromotionAdd(newItem);
                    }
                } else {
                    if (manager.CheckIfNameDoesNotExist(newItem))
                    {
                        newItem.PercentageOff = newItem.PercentageOffForm;
                        var a = manager.PromotionAdd(newItem);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                //Reset Form Values To Original
                var form = new PromotionAddForm();
                form.Products = manager.ProductsWithoutPromotions();
                form.BeginDate = DateTime.Today;
                form.EndDate = DateTime.Today;
                form.ProductsEnumerable = manager.ProductsWithPromotions();
                ViewBag.ProductName = "Product Name";
                ViewBag.PromotionName = "Promotion Name";
                ViewBag.Discount = "Discount Price";
                return View(form);
            }
        }

        // GET: Promotion/Edit/5
        public ActionResult Edit(int id)
        {
            var form = new PromotionEditForm();
            form = AutoMapper.Mapper.Map<PromotionEditForm>(manager.PromotionGetOne(id));

            //Make Sure User cannot access None Promotion
            if (form.PromotionName != "None"){
                form.Products = manager.ProductGetAllIEnumerable().ToList();
                form.ProductsEnumerable = manager.ProductWithPromotion(id);
                //form.ProductsEnumerable = new List<Product_vm>();
                
                return View(form);
            }else{
                return RedirectToAction("Index");
            }
        }

        // POST: Promotion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            string convert;
            int[] ProductIds;

            try
            {
                //Get the products that have been selected
                convert = collection["System.Collections.Generic.List`1[Assignment_8.Controllers.Product_vm]"];
                ProductIds = convert.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

                var promo_vm = manager.PromotionGetOne(id);
                manager.PromotionEdit(promo_vm, ProductIds);

                return RedirectToAction("Index");
            }
            catch
            {
                //Reset Form Values To Original
                var form = new PromotionEditForm();
                form = AutoMapper.Mapper.Map<PromotionEditForm>(manager.PromotionGetOne(id));
                form.Products = manager.ProductGetAllIEnumerable().ToList();
                form.ProductsEnumerable = manager.ProductWithPromotion(id);

                return View(form);
            }
        }

        // GET: Promotion/Delete/5
        public ActionResult Delete(int id)
        {
            var form = AutoMapper.Mapper.Map<PromotionDeleteForm>(manager.PromotionGetOne(id));
            //Make Sure User cannot access None Promotion
            if (form.PromotionName != "None")
            {
                form.ProductsEnumerable = manager.ProductWithPromotion(id);
                ViewBag.ProductName = "Product Name";
                ViewBag.PromotionName = "Promotion Name";
                ViewBag.Discount = "Discount Price";
                return View(form);
            }else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Promotion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Promotion_vm item)
        {
            bool pass;
            try
            {
                pass = manager.PromotionDelete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                //Reset Form Values To Original
                var form = AutoMapper.Mapper.Map<PromotionDeleteForm>(manager.PromotionGetOne(id));
                form.ProductsEnumerable = manager.ProductWithPromotion(id);
                ViewBag.ProductName = "Product Name";
                ViewBag.PromotionName = "Promotion Name";
                ViewBag.Discount = "Discount Price";
                return View(form);
            }
        }
    }
}
