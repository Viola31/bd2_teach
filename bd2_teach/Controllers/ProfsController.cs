using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bd2_teach.Models;

namespace bd2_teach.Controllers
{
    public class ProfsController : Controller
    {
        private bd2Entities db = new bd2Entities();

        // GET: Profs
        public ActionResult Index()
        {
            var prof = db.Prof.Include(p => p.Position_prof);
            return View(prof.ToList());
        }

        // GET: Profs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prof prof = db.Prof.Find(id);
            if (prof == null)
            {
                return HttpNotFound();
            }
            return View(prof);
        }

        // GET: Profs/Create
        public ActionResult Create()
        {
            ViewBag.Position_prof_id = new SelectList(db.Position_prof, "Position_prof_id", "Pos_name");
            return View();
        }

        // POST: Profs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Professors_id,FullName,Position_prof_id")] Prof prof)
        {
            if (ModelState.IsValid)
            {
                db.Prof.Add(prof);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Position_prof_id = new SelectList(db.Position_prof, "Position_prof_id", "Pos_name", prof.Position_prof_id);
            return View(prof);
        }

        // GET: Profs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prof prof = db.Prof.Find(id);
            if (prof == null)
            {
                return HttpNotFound();
            }
            ViewBag.Position_prof_id = new SelectList(db.Position_prof, "Position_prof_id", "Pos_name", prof.Position_prof_id);
            return View(prof);
        }

        // POST: Profs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Professors_id,FullName,Position_prof_id")] Prof prof)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prof).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Position_prof_id = new SelectList(db.Position_prof, "Position_prof_id", "Pos_name", prof.Position_prof_id);
            return View(prof);
        }

        // GET: Profs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prof prof = db.Prof.Find(id);
            if (prof == null)
            {
                return HttpNotFound();
            }
            return View(prof);
        }

        // POST: Profs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prof prof = db.Prof.Find(id);
            db.Prof.Remove(prof);
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
