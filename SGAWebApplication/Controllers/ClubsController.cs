using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGAWebApplication.Models;

namespace SGAWebApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClubsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clubs
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.clubs.ToList());
        }

        // GET: Clubs/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clubs clubs = db.clubs.Find(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // GET: Clubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Budget")] Clubs clubs)
        {
            if (ModelState.IsValid)
            {
                db.clubs.Add(clubs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clubs);
        }

        // GET: Clubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clubs clubs = db.clubs.Find(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Budget")] Clubs clubs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clubs);
        }

        // GET: Clubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clubs clubs = db.clubs.Find(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clubs clubs = db.clubs.Find(id);
            db.clubs.Remove(clubs);
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
