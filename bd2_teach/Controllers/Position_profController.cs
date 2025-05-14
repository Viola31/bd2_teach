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
    public class Position_profController : Controller
    {
        private bd2Entities db = new bd2Entities();

        // GET: Position_prof
        public ActionResult Index()
        {
            return View(db.Position_prof.ToList());
        }

        // GET: Position_prof/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position_prof position_prof = db.Position_prof.Find(id);
            if (position_prof == null)
            {
                return HttpNotFound();
            }
            return View(position_prof);
        }

        // GET: Position_prof/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Position_prof/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Position_prof_id,Pos_name")] Position_prof position_prof)
        {
            if (ModelState.IsValid)
            {
                db.Position_prof.Add(position_prof);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(position_prof);
        }

        // GET: Position_prof/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position_prof position_prof = db.Position_prof.Find(id);
            if (position_prof == null)
            {
                return HttpNotFound();
            }
            return View(position_prof);
        }

        // POST: Position_prof/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Position_prof_id,Pos_name")] Position_prof position_prof)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position_prof).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position_prof);
        }

        // GET: Position_prof/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position_prof position_prof = db.Position_prof.Find(id);
            if (position_prof == null)
            {
                return HttpNotFound();
            }
            return View(position_prof);
        }

        // POST: Position_prof/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Position_prof position_prof = db.Position_prof.Find(id);
            db.Position_prof.Remove(position_prof);
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
