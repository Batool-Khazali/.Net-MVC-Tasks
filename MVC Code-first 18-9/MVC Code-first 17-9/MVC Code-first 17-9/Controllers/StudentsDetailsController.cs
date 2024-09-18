using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Code_first_17_9.Models;

namespace MVC_Code_first_17_9.Controllers
{
    public class StudentsDetailsController : Controller
    {
        private MyDb db = new MyDb();

        // GET: StudentsDetails
        public ActionResult Index()
        {
            var studentsDetails = db.StudentsDetails.Include(s => s.Student);
            return View(studentsDetails.ToList());
        }

        // GET: StudentsDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsDetails studentsDetails = db.StudentsDetails.Find(id);
            if (studentsDetails == null)
            {
                return HttpNotFound();
            }
            return View(studentsDetails);
        }

        // GET: StudentsDetails/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Students, "Id", "Name");
            return View();
        }

        // POST: StudentsDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,phone,BirthDate,Address,ParentName")] StudentsDetails studentsDetails)
        {
            if (ModelState.IsValid)
            {
                db.StudentsDetails.Add(studentsDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Students, "Id", "Name", studentsDetails.ID);
            return View(studentsDetails);
        }

        // GET: StudentsDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsDetails studentsDetails = db.StudentsDetails.Find(id);
            if (studentsDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Students, "Id", "Name", studentsDetails.ID);
            return View(studentsDetails);
        }

        // POST: StudentsDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,phone,BirthDate,Address,ParentName")] StudentsDetails studentsDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Students, "Id", "Name", studentsDetails.ID);
            return View(studentsDetails);
        }

        // GET: StudentsDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsDetails studentsDetails = db.StudentsDetails.Find(id);
            if (studentsDetails == null)
            {
                return HttpNotFound();
            }
            return View(studentsDetails);
        }

        // POST: StudentsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentsDetails studentsDetails = db.StudentsDetails.Find(id);
            db.StudentsDetails.Remove(studentsDetails);
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
