using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public class Students_Controller : Controller
    {
        private TestEntities db = new TestEntities();

        // GET: Students_
        public ActionResult Index()
        {
            return View(db.Students_.ToList());
        }

        // GET: Students_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_ students_ = db.Students_.Find(id);
            if (students_ == null)
            {
                return HttpNotFound();
            }
            return View(students_);
        }

        // GET: Students_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Age")] Students_ students_)
        {
            if (ModelState.IsValid)
            {
                var student = students_;
               
                db.Students_.Add(students_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students_);
        }

        // GET: Students_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_ students_ = db.Students_.Find(id);
            if (students_ == null)
            {
                return HttpNotFound();
            }
            return View(students_);
        }

        // POST: Students_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Age")] Students_ students_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students_);
        }

        // GET: Students_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_ students_ = db.Students_.Find(id);
            if (students_ == null)
            {
                return HttpNotFound();
            }
            return View(students_);
        }

        // POST: Students_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students_ students_ = db.Students_.Find(id);
            db.Students_.Remove(students_);
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
