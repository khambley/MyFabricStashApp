using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyFabricStashApp.Models;
using System.IO;

namespace MyFabricStashApp.Controllers
{
    public class ReceiptsController : Controller
    {
        private MyFabricStashDb db = new MyFabricStashDb();

        // GET: Receipts
        public ActionResult Index()
        {
            var orderedList = db.Receipts.Include(s => s.Source)
                .OrderByDescending(d => d.ReceiptDate)
                .Select(r => new ReceiptsListViewModel
                {
                    ReceiptId = r.ReceiptId,
                    ReceiptNumber = r.ReceiptNumber,
                    SourceId = r.SourceId,
                    SourceName = r.Source.SourceName,
                    ReceiptImagePath = r.ReceiptImagePath,
                    ReceiptDate = r.ReceiptDate,
                    Description = r.Description
                });
            return View(orderedList);
        }

        // GET: Receipts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // GET: Receipts/Create
        public ActionResult Create()
        {
            List<Source> lstSources = db.Sources.ToList();

            lstSources.Insert(0, new Source { SourceId = 0, SourceName = "--Select Source--" });

            ViewBag.SourceId = new SelectList(lstSources, "SourceId", "SourceName");

            return View();
        }

        // POST: Receipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReceiptId,ReceiptImagePath,SourceId,ReceiptDate,Description")] Receipt receipt, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);
                    string receiptId = receipt.ReceiptId.ToString();
                    string myfile = receiptId + "_" + filename;
                    var path = Path.Combine(Server.MapPath("~/receipts"), myfile);
                    receipt.ReceiptImagePath = myfile;
                    file.SaveAs(path);
                }
                
                db.Receipts.Add(receipt);
                db.SaveChanges();
                receipt.ReceiptNumber = "REC0" + receipt.ReceiptId.ToString() + receipt.ReceiptDate.ToString("yyyyMMdd") + receipt.SourceId;
                db.Entry(receipt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // POST: Receipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReceiptId,ReceiptImagePath,ReceiptDate,Description")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receipt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receipt);
        }

        // GET: Receipts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receipt receipt = db.Receipts.Find(id);
            db.Receipts.Remove(receipt);
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
