using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SGAWebApplication.Models;

namespace SGAWebApplication.Controllers
{
    [Authorize(Roles = "Student,Admin")]
    public class PointsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var model = new PointsViewModel
            {
                clubEvents = db.clubEvents.ToList(),
                events = db.events.ToList()
            };

            return View(model);
        }

        public ActionResult Events()
        {
            var userId = User.Identity.GetUserId();
            var currentUser = db.Users.Find(userId);
            if(db.events.Where(e => e.Attendees.Select(a => a.Id).Contains(userId)).FirstOrDefault() != null)
            {
                TempData["Accepted"] = "Already";
                return RedirectToAction("Index");
            }



            return RedirectToAction("Index");
        }
    }
}