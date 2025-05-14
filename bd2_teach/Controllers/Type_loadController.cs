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
    public class Type_loadController : Controller
    {
        private bd2Entities db = new bd2Entities();

        // GET: Type_load
        public ActionResult Index()
        {
            return View(db.Type_load.ToList());
        }

        // GET: Type_load/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_load type_load = db.Type_load.Find(id);
            if (type_load == null)
            {
                return HttpNotFound();
            }
            return View(type_load);
        }

        // GET: Type_load/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Type_load/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Type_load_id,T_l_name")] Type_load type_load)
        {
            if (ModelState.IsValid)
            {
                db.Type_load.Add(type_load);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type_load);
        }

        // GET: Type_load/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_load type_load = db.Type_load.Find(id);
            if (type_load == null)
            {
                return HttpNotFound();
            }
            return View(type_load);
        }

        // POST: Type_load/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Type_load_id,T_l_name")] Type_load type_load)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type_load).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type_load);
        }

        // GET: Type_load/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_load type_load = db.Type_load.Find(id);
            if (type_load == null)
            {
                return HttpNotFound();
            }
            return View(type_load);
        }

        // POST: Type_load/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Type_load type_load = db.Type_load.Find(id);
            db.Type_load.Remove(type_load);
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
