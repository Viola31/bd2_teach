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
    public class AllowsController : Controller
    {
        private bd2Entities db = new bd2Entities();

        // GET: Allows
        public ActionResult Index()
        {
            var allow = db.Allow.Include(a => a.Position_prof).Include(a => a.Type_load);
            return View(allow.ToList());
        }

        // GET: Allows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allow allow = db.Allow.Find(id);
            if (allow == null)
            {
                return HttpNotFound();
            }
            return View(allow);
        }

        // GET: Allows/Create
        public ActionResult Create()
        {
            ViewBag.Position_prof_id = new SelectList(db.Position_prof, "Position_prof_id", "Pos_name");
            ViewBag.Type_load_id = new SelectList(db.Type_load, "Type_load_id", "T_l_name");
            return View();
        }

        // POST: Allows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Allow_id,Position_prof_id,Type_load_id")] Allow allow)
        {
            if (ModelState.IsValid)
            {
                db.Allow.Add(allow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Position_prof_id = new SelectList(db.Position_prof, "Position_prof_id", "Pos_name", allow.Position_prof_id);
            ViewBag.Type_load_id = new SelectList(db.Type_load, "Type_load_id", "T_l_name", allow.Type_load_id);
            return View(allow);
        }

        // GET: Allows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allow allow = db.Allow.Find(id);
            if (allow == null)
            {
                return HttpNotFound();
            }
            ViewBag.Position_prof_id = new SelectList(db.Position_prof, "Position_prof_id", "Pos_name", allow.Position_prof_id);
            ViewBag.Type_load_id = new SelectList(db.Type_load, "Type_load_id", "T_l_name", allow.Type_load_id);
            return View(allow);
        }

        // POST: Allows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Allow_id,Position_prof_id,Type_load_id")] Allow allow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Position_prof_id = new SelectList(db.Position_prof, "Position_prof_id", "Pos_name", allow.Position_prof_id);
            ViewBag.Type_load_id = new SelectList(db.Type_load, "Type_load_id", "T_l_name", allow.Type_load_id);
            return View(allow);
        }

        // GET: Allows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allow allow = db.Allow.Find(id);
            if (allow == null)
            {
                return HttpNotFound();
            }
            return View(allow);
        }

        // POST: Allows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Allow allow = db.Allow.Find(id);
            db.Allow.Remove(allow);
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
