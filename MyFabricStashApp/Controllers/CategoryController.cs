using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MyFabricStashApp.Models;

namespace MyFabricStashApp.Controllers
{
    public class CategoryController : Controller
    {
        private MyFabricStashDb db = new MyFabricStashDb();

        public ActionResult Index()
        {
            var orderedList = db.MainCategories.Include(c => c.SubCategories1)
                .OrderBy(n => n.Name).ToList();
            return View(orderedList);
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var model = db.MainCategories.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditCategory(MainCategory mainCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SubCategories", new { id = mainCategory.MainCategoryId });
            }
            return View(mainCategory);
        }
        // GET: Category/DeleteMainCategory/5
        public ActionResult DeleteMainCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCategory mainCategory = db.MainCategories.Find(id);

            if (mainCategory == null)
            {
                return HttpNotFound();
            }
            return View(mainCategory);
        }

        // POST: Category/DeleteMainCategory/5
        [HttpPost, ActionName("DeleteMainCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainCategory mainCategory = db.MainCategories.Find(id);
            db.MainCategories.Remove(mainCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Category/DeleteSubCategory/5
        public ActionResult DeleteSubCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory1 subCategory = db.SubCategories1.Find(id);

            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: Category/DeleteSubCategory/5
        [HttpPost, ActionName("DeleteSubCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSubConfirmed(int id)
        {
            SubCategory1 subCategory = db.SubCategories1.Find(id);
            db.SubCategories1.Remove(subCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SubCategories([Bind(Prefix="id")] int maincategoryId)
        {
            var mainCategory = db.MainCategories.Find(maincategoryId);
            List<SubCategory1> subCategories1 = new List<SubCategory1>();
            subCategories1 = db.SubCategories1.OrderBy(n => n.Name).Where(s => s.MainCategoryId == maincategoryId).ToList();
            if (mainCategory != null)
            {
                return View(mainCategory);
            }
            return HttpNotFound();
        }
        [HttpGet]
        public ActionResult CreateSubCategory(int maincategoryId, string maincategoryName)
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSubCategory(SubCategory1 subCategory1)
        {
            if (ModelState.IsValid)
            {
                db.SubCategories1.Add(subCategory1);
                db.SaveChanges();
                return RedirectToAction("SubCategories", new { id = subCategory1.MainCategoryId });
            }
            return View(subCategory1);
        }
        [HttpGet]
        public ActionResult EditSubCategory(int id)
        {
            var model = db.SubCategories1.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditSubCategory(SubCategory1 subcategory1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategory1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SubCategories", new { id = subcategory1.MainCategoryId });
            }
            return View(subcategory1);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //if(this.HttpContext.Request.IsAjaxRequest() != true)
            //{
            //    return RedirectToAction("Index", "Fabric");
            //}
            return View("CreateCategory");
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "MainCategoryId,Name")] MainCategory category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.MainCategories.Add(category);
                    db.SaveChanges();

                    var dbCategory = db.MainCategories.Where(m => m.Name == category.Name).SingleOrDefault();
                    return RedirectToAction("Index", "Category");
                } else
                {
                    string errMsg = "Something failed, probably validation";
                    var er = ModelState.Values.FirstOrDefault();
                    if (er != null && er.Value != null && !String.IsNullOrEmpty(er.Value.AttemptedValue))
                    {
                        errMsg = "\"" + er.Value.AttemptedValue + "\" Does not validate"; 
                    }
                    return Json(new { Error = errMsg });
                }
            } catch (InvalidOperationException ioex)
            {
                if (ioex.Message.Contains("Sequence contains more than one element"))
                {
                    return Json(new { Error = "Value provided exists in DB, enter a unique value" });
                }
                return Json(new { Error = ioex.Message });
            } catch (Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
        }

    }
}