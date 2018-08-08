using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyFabricStashApp.Models;

namespace MyFabricStashApp.Controllers
{
    public class PurchasesController : Controller
    {
        private MyFabricStashDb db = new MyFabricStashDb();

        // GET: Purchases
        public ActionResult Index()
        {
            //var orderedList = db.Purchases.Include(c => c.Fabrics)
            //    .OrderBy(n => n.Name).ToList();
            var orderedList = db.Purchases.Include(f => f.Fabric)
                .Select(p => new PurchasesListViewModel
                {
                    PurchaseId = p.PurchaseId,
                    PurchaseDate = p.PurchaseDate,
                    PurchaseQuantity = p.PurchaseQuantity,
                    PurchasePrice = p.PurchasePrice,
                    PurchaseTotal = p.PurchaseTotal,
                    FabricId = p.FabricId,
                    FabricName = p.Fabric.Name,
                    FabricImagePath = p.Fabric.ImagePath,
                    ReceiptId = p.ReceiptId,
                    SourceId = p.SourceId,
                    SourceName = p.Source.SourceName
                });

            return View(orderedList);
        }
        public ActionResult FabricPurchases([Bind(Prefix="id")]int fabricId)
        {
            var fabric = db.Fabrics.Find(fabricId);
            if (fabric != null)
            {
                return View(fabric);
            }
            return HttpNotFound();
        }
        // GET: Purchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: Purchases/Create
        public ActionResult Create()
        {
            List<Fabric> lstFabrics = db.Fabrics.ToList();

            ViewBag.FabricId = new SelectList(lstFabrics, "FabricId", "Name", "FabricId");

            return View();
        }
        [HttpGet]
        public ActionResult CreateFabricPurchase(int id)
        {
            Fabric fabric = db.Fabrics.Find(id);
            if (fabric == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricName = fabric.Name;
            ViewBag.sFabricId = fabric.FabricId;
            ViewBag.FabricId = id;

            List<Receipt> lstReceipts = db.Receipts.ToList();

            ViewBag.ReceiptId = new SelectList(lstReceipts, "ReceiptId", "ReceiptImagePath", "ReceiptId");

            List<Source> lstSources = db.Sources.ToList();

            ViewBag.SourceId = new SelectList(lstSources, "SourceId", "SourceName", "SourceId");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFabricPurchase([Bind(Include = "PurchaseId,PurchaseDate,PurchaseQuantity,PurchasePrice,PurchaseTotal,FabricId,ReceiptId,SourceId,Notes")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchase);
                db.SaveChanges();
                return RedirectToAction("Details", "Fabric", new { id = purchase.FabricId });
            }
            return View(purchase);
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseId,PurchaseDate,PurchaseQuantity,PurchasePrice,PurchaseTotal,FabricId,ReceiptId,SourceId,Notes")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchase);
        }
        public JsonResult GetFabricsList()
        {
            var result = db.Fabrics
                .OrderBy(n => n.Name)
                .ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Purchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseId,PurchaseDate,PurchaseQuantity,PurchasePrice,PurchaseTotal,FabricId,ReceiptId,SourceId,Notes")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = db.Purchases.Find(id);
            db.Purchases.Remove(purchase);
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
