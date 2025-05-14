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
    public class TeachingsController : Controller
    {
        private bd2Entities db = new bd2Entities();

        // GET: Teachings
        public ActionResult Index()
        {
            var teaching = db.Teaching.Include(t => t.Discipline).Include(t => t.Prof).Include(t => t.Type_load);
            return View(teaching.ToList());
        }

        // GET: Teachings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teaching teaching = db.Teaching.Find(id);
            if (teaching == null)
            {
                return HttpNotFound();
            }
            return View(teaching);
        }

        // GET: Teachings/Create
        public ActionResult Create()
        {
            ViewBag.Discipline_id = new SelectList(db.Discipline, "Discipline_id", "Dis_name");
            ViewBag.professors_id = new SelectList(db.Prof, "Professors_id", "FullName");
            ViewBag.Type_load_id = new SelectList(db.Type_load, "Type_load_id", "T_l_name");
            return View();
        }

        // POST: Teachings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Teaching_id,Hours_,Discipline_id,Type_load_id,professors_id")] Teaching teaching)
        {
            if (ModelState.IsValid)
            {
                db.Teaching.Add(teaching);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Discipline_id = new SelectList(db.Discipline, "Discipline_id", "Dis_name", teaching.Discipline_id);
            ViewBag.professors_id = new SelectList(db.Prof, "Professors_id", "FullName", teaching.professors_id);
            ViewBag.Type_load_id = new SelectList(db.Type_load, "Type_load_id", "T_l_name", teaching.Type_load_id);
            return View(teaching);
        }

        // GET: Teachings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teaching teaching = db.Teaching.Find(id);
            if (teaching == null)
            {
                return HttpNotFound();
            }
            ViewBag.Discipline_id = new SelectList(db.Discipline, "Discipline_id", "Dis_name", teaching.Discipline_id);
            ViewBag.professors_id = new SelectList(db.Prof, "Professors_id", "FullName", teaching.professors_id);
            ViewBag.Type_load_id = new SelectList(db.Type_load, "Type_load_id", "T_l_name", teaching.Type_load_id);
            return View(teaching);
        }

        // POST: Teachings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Teaching_id,Hours_,Discipline_id,Type_load_id,professors_id")] Teaching teaching)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teaching).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Discipline_id = new SelectList(db.Discipline, "Discipline_id", "Dis_name", teaching.Discipline_id);
            ViewBag.professors_id = new SelectList(db.Prof, "Professors_id", "FullName", teaching.professors_id);
            ViewBag.Type_load_id = new SelectList(db.Type_load, "Type_load_id", "T_l_name", teaching.Type_load_id);
            return View(teaching);
        }

        // GET: Teachings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teaching teaching = db.Teaching.Find(id);
            if (teaching == null)
            {
                return HttpNotFound();
            }
            return View(teaching);
        }

        // POST: Teachings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teaching teaching = db.Teaching.Find(id);
            db.Teaching.Remove(teaching);
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
