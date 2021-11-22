using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstuctionManagement.Models;

namespace ConstuctionManagement.Controllers
{
    public class ItemController : Controller
    {
        private ConstructionEntities2 db = new ConstructionEntities2();

        // GET: Item
        public ActionResult Index()
        {
            var tbl_itemmaster = db.tbl_itemmaster.Include(t => t.tbl_project).Include(t => t.tbl_stock);
            return View(tbl_itemmaster.ToList());
        }

        // GET: Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_itemmaster tbl_itemmaster = db.tbl_itemmaster.Find(id);
            if (tbl_itemmaster == null)
            {
                return HttpNotFound();
            }
            return View(tbl_itemmaster);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            ViewBag.project_id = new SelectList(db.tbl_project, "project_id", "project_name");
            ViewBag.product_id = new SelectList(db.tbl_stock, "product_id", "product_id");
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,unit,item,item_code,project_id")] tbl_itemmaster tbl_itemmaster)
        {
            if (ModelState.IsValid)
            {
                db.tbl_itemmaster.Add(tbl_itemmaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.project_id = new SelectList(db.tbl_project, "project_id", "project_name", tbl_itemmaster.project_id);
            ViewBag.product_id = new SelectList(db.tbl_stock, "product_id", "product_id", tbl_itemmaster.product_id);
            return View(tbl_itemmaster);
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_itemmaster tbl_itemmaster = db.tbl_itemmaster.Find(id);
            if (tbl_itemmaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.project_id = new SelectList(db.tbl_project, "project_id", "project_name", tbl_itemmaster.project_id);
            ViewBag.product_id = new SelectList(db.tbl_stock, "product_id", "product_id", tbl_itemmaster.product_id);
            return View(tbl_itemmaster);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,unit,item,item_code,project_id")] tbl_itemmaster tbl_itemmaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_itemmaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.project_id = new SelectList(db.tbl_project, "project_id", "project_name", tbl_itemmaster.project_id);
            ViewBag.product_id = new SelectList(db.tbl_stock, "product_id", "product_id", tbl_itemmaster.product_id);
            return View(tbl_itemmaster);
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_itemmaster tbl_itemmaster = db.tbl_itemmaster.Find(id);
            if (tbl_itemmaster == null)
            {
                return HttpNotFound();
            }
            return View(tbl_itemmaster);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_itemmaster tbl_itemmaster = db.tbl_itemmaster.Find(id);
            db.tbl_itemmaster.Remove(tbl_itemmaster);
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
