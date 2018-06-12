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
    public class ClubEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClubEvents
        public ActionResult Index()
        {
            var clubEvents = db.clubEvents.Include(c => c.Club);
            return View(clubEvents.ToList());
        }

        // GET: ClubEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubEvents clubEvents = db.clubEvents.Find(id);
            if (clubEvents == null)
            {
                return HttpNotFound();
            }
            return View(clubEvents);
        }

        // GET: ClubEvents/Create
        public ActionResult Create()
        {
            ViewBag.ClubId = new SelectList(db.clubs, "Id", "Name");
            return View();
        }

        // POST: ClubEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,PointKey,PointValue,EventCount,ClubId,Date")] ClubEvents clubEvents)
        {
            if (ModelState.IsValid)
            {
                db.clubEvents.Add(clubEvents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClubId = new SelectList(db.clubs, "Id", "Name", clubEvents.ClubId);
            return View(clubEvents);
        }

        // GET: ClubEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubEvents clubEvents = db.clubEvents.Find(id);
            if (clubEvents == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubId = new SelectList(db.clubs, "Id", "Name", clubEvents.ClubId);
            return View(clubEvents);
        }

        // POST: ClubEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,PointKey,PointValue,EventCount,ClubId,Date")] ClubEvents clubEvents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubEvents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClubId = new SelectList(db.clubs, "Id", "Name", clubEvents.ClubId);
            return View(clubEvents);
        }

        // GET: ClubEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubEvents clubEvents = db.clubEvents.Find(id);
            if (clubEvents == null)
            {
                return HttpNotFound();
            }
            return View(clubEvents);
        }

        // POST: ClubEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClubEvents clubEvents = db.clubEvents.Find(id);
            db.clubEvents.Remove(clubEvents);
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
