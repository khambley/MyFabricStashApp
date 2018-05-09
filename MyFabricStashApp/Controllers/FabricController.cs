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
    public class FabricController : Controller
    {
        private MyFabricStashDb db = new MyFabricStashDb();

        // GET: Fabric
        public ActionResult Index(string searchTerm = null)
        {
            var model = db.Fabrics
                .OrderByDescending(f => f.ItemsSold)
                .Where(f => searchTerm == null || f.Name.StartsWith(searchTerm))
                .Select(f => new FabricListViewModel
                {
                    FabricId = f.FabricId,
                    Name = f.Name,
                    MainCategoryId = f.MainCategoryId,
                    SubCategory1Id = f.SubCategory1Id,
                    ImagePath = f.ImagePath,
                    Location = f.Location,
                    Type = f.Type,
                    Weight = f.Weight,
                    Content = f.Content,
                    Design = f.Design,
                    Brand = f.Brand,
                    Quantity = f.Quantity,
                    Width = f.Width,
                    Source = f.Source,
                    Notes = f.Notes,
                    ItemsSold = f.ItemsSold,
                    PurchaseCount = f.Purchases.Count()
                });
            return View(model);
        }
        public ActionResult UploadImage(HttpPostedFileBase file, Fabric model)
        {
            if(file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/images/"), pic);
                file.SaveAs(path);
                model.ImagePath = path;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("UploadImage");
        }

        // GET: Fabric/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabric fabric = db.Fabrics.Find(id);
            if (fabric == null)
            {
                return HttpNotFound();
            }
            return View(fabric);
        }
        public JsonResult GetSubCategories1ByMainCategoryId(int id)
        {
            List<SubCategory1> subCategories1 = new List<SubCategory1>();
            if(id > 0)
            {
                subCategories1 = db.SubCategories1.Where(s => s.MainCategoryId == id).ToList();
            } else
            {
                subCategories1.Insert(0, new SubCategory1 { SubCategory1Id = 0, Name = "--Select a main category first" });
            }
            var result = (from r in subCategories1
                          select new
                          {
                              id = r.SubCategory1Id,
                              name = r.Name
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Fabric/Create
        public ActionResult Create()
        {
            List<MainCategory> lstMainCategories = db.MainCategories.ToList();
            lstMainCategories.Insert(0, new MainCategory { MainCategoryId = 0, Name = "--Select Category--" });
            List<SubCategory1> lstSubCategories1 = new List<SubCategory1>();
            ViewBag.MainCategoryId = new SelectList(lstMainCategories, "MainCategoryId", "Name");
            ViewBag.SubCategory1Id = new SelectList(lstSubCategories1, "SubCategory1Id", "Name");
            return View();
        }

        // POST: Fabric/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FabricId,MainCategory,SubCategory1,SubCategory2,Name,ImagePath,Location,Type,Weight,Content,Design,Brand,Quantity,Width,Source,Notes,ItemsSold")] Fabric fabric, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileName(file.FileName);
                string fabricId = fabric.FabricId.ToString();
                string myfile = fabricId + "_" + filename;
                var path = Path.Combine(Server.MapPath("~/images"), myfile);
                fabric.ImagePath = myfile;
                file.SaveAs(path);
                db.Fabrics.Add(fabric);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fabric);
        }

        // GET: Fabric/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabric fabric = db.Fabrics.Find(id);
            if (fabric == null)
            {
                return HttpNotFound();
            }
            return View(fabric);
        }

        // POST: Fabric/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FabricId,MainCategory,SubCategory1,SubCategory2,Name,ImagePath,Location,Type,Weight,Content,Design,Brand,Quantity,Width,Source,Notes,ItemsSold")] Fabric fabric, HttpPostedFileBase file)
        {
            //if (file != null) { 
            //    var filename = Path.GetFileName(file.FileName);
            //    var path = Path.Combine(Server.MapPath("~/images"), filename);
            //    fabric.ImagePath = path;
            //    db.Fabrics.Add(fabric);
            //    db.SaveChanges();
            //    file.SaveAs(path);
            //}
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/images"), filename);
                fabric.ImagePath = filename;
                db.Entry(fabric).State = EntityState.Modified;
                db.SaveChanges();
                file.SaveAs(path);
                return RedirectToAction("Index");
            }
            return View(fabric);
        }

        // GET: Fabric/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabric fabric = db.Fabrics.Find(id);
            if (fabric == null)
            {
                return HttpNotFound();
            }
            return View(fabric);
        }

        // POST: Fabric/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fabric fabric = db.Fabrics.Find(id);
            db.Fabrics.Remove(fabric);
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
