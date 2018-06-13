using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SGAWebApplication.Models;

namespace SGAWebApplication.Controllers
{
    [Authorize]
    public class ClubsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clubs
        [AllowAnonymous]
        public ActionResult Index()
        {

            var UserId = User.Identity.GetUserId();
            if (User.IsInRole("Teacher"))
            {
                var teacherClubEvents = db.clubs.Where(c => c.AdvisorId == UserId);

                return View(teacherClubEvents);
            }
            var currentClub = db.clubs.Where(c => c.Members.Select(m => m.Id).Contains(UserId));
            return View(db.clubs.Except(currentClub));
        }

        // GET: Clubs/Details/5
        [Authorize(Roles = "Teacher,Admin,Student")]
        public ActionResult Details(int? id)
        {
            var currentUser = db.Users.Find(User.Identity.GetUserId());
            if (id == null)
            {
                if (currentUser.ClubsId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                id = currentUser.ClubsId;
            }
            var model = new ClubDetailsViewModel
            {
                clubs = db.clubs.Find(id),
                clubEvents = db.clubEvents.Where(e => e.ClubId == id).ToList(),
                advisor = db.Users.Find(db.clubs.Find(id).AdvisorId)
            };
            if (model.clubs == null || model.clubEvents == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [Authorize(Roles = "Student,Admin")]
        public ActionResult Join(int? id)
        {
            TempData["InClub"] = "";
            var currentUser = db.Users.Find(User.Identity.GetUserId());

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (currentUser.ClubsId != null)
            {
                TempData["JoiningClub"] = id;
                TempData["InClub"] = "Yes";
                return RedirectToAction("Index", "Clubs");
            }

            currentUser.ClubsId = id;
            db.SaveChanges();
            return RedirectToAction("Details", "Clubs", new { id = currentUser.ClubsId });
        }

        [Authorize(Roles = "Student,Admin")]
        public ActionResult LeaveJoin()
        {
            var currentUser = db.Users.Find(User.Identity.GetUserId());

            if (TempData["JoiningClub"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            currentUser.ClubsId = (int)TempData["JoiningClub"];
            db.SaveChanges();
            return RedirectToAction("Details", "Clubs", new { id = currentUser.ClubsId });
        }

        // GET: Clubs/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
