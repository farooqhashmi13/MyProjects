using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_Exam.Models;

namespace Online_Exam.Controllers
{
    public class TestCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestCategories
        public ActionResult Index()
        {
            return View(db.TestCategories.ToList());
        }

        // GET: TestCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestCategory testCategory = db.TestCategories.Find(id);
            if (testCategory == null)
            {
                return HttpNotFound();
            }
            return View(testCategory);
        }

        // GET: TestCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] TestCategory testCategory)
        {
            if (ModelState.IsValid)
            {
                db.TestCategories.Add(testCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testCategory);
        }

        // GET: TestCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestCategory testCategory = db.TestCategories.Find(id);
            if (testCategory == null)
            {
                return HttpNotFound();
            }
            return View(testCategory);
        }

        // POST: TestCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] TestCategory testCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testCategory);
        }

        // GET: TestCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestCategory testCategory = db.TestCategories.Find(id);
            if (testCategory == null)
            {
                return HttpNotFound();
            }
            return View(testCategory);
        }

        // POST: TestCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestCategory testCategory = db.TestCategories.Find(id);
            db.TestCategories.Remove(testCategory);
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
