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
    public class ExpenseController : Controller
    {
        private ConstructionEntities2 db = new ConstructionEntities2();

        // GET: Expense
        public ActionResult Index()
        {
            var tbl_expensemaster = db.tbl_expensemaster.Include(t => t.tbl_project);
            return View(tbl_expensemaster.ToList());
        }

        // GET: Expense/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_expensemaster tbl_expensemaster = db.tbl_expensemaster.Find(id);
            if (tbl_expensemaster == null)
            {
                return HttpNotFound();
            }
            return View(tbl_expensemaster);
        }

        // GET: Expense/Create
        public ActionResult Create()
        {
            ViewBag.project_id = new SelectList(db.tbl_project, "project_id", "project_name");
            return View();
        }

        // POST: Expense/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "e_id,e_name,e_date,user_id,project_id")] tbl_expensemaster tbl_expensemaster)
        {
            if (ModelState.IsValid)
            {
                db.tbl_expensemaster.Add(tbl_expensemaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.project_id = new SelectList(db.tbl_project, "project_id", "project_name", tbl_expensemaster.project_id);
            return View(tbl_expensemaster);
        }

        // GET: Expense/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_expensemaster tbl_expensemaster = db.tbl_expensemaster.Find(id);
            if (tbl_expensemaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.project_id = new SelectList(db.tbl_project, "project_id", "project_name", tbl_expensemaster.project_id);
            return View(tbl_expensemaster);
        }

        // POST: Expense/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "e_id,e_name,e_date,user_id,project_id")] tbl_expensemaster tbl_expensemaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_expensemaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.project_id = new SelectList(db.tbl_project, "project_id", "project_name", tbl_expensemaster.project_id);
            return View(tbl_expensemaster);
        }

        // GET: Expense/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_expensemaster tbl_expensemaster = db.tbl_expensemaster.Find(id);
            if (tbl_expensemaster == null)
            {
                return HttpNotFound();
            }
            return View(tbl_expensemaster);
        }

        // POST: Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_expensemaster tbl_expensemaster = db.tbl_expensemaster.Find(id);
            db.tbl_expensemaster.Remove(tbl_expensemaster);
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
