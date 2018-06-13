using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return View();
        }

        public ActionResult Events([Bind(Include = "eventKey")] PointsViewModel key)
        {
            var userId = User.Identity.GetUserId();
            var currentUser = db.Users.Find(userId);
            var currentPoints = currentUser.Points;

            if(key.eventKey == null)
            {
                TempData["Accepted"] = "Nothing";
                return RedirectToAction("Index");
            }

            foreach(var events in db.events.ToList())
            {
                if(events.RegularKey == key.eventKey)
                {

                    if(events.Attendees.Select(a => a.Id).Contains(userId) == true)
                    {
                        TempData["Accepted"] = "Already";
                        return RedirectToAction("Index");
                    }

                    events.Attendees.Add(currentUser);
                    currentUser.Points = currentUser.Points + events.RegularValue;
                    events.EventCount = events.EventCount + 1;
                    TempData["Accepted"] = "Acc";
                }
                else if(events.VolunteerKey == key.eventKey)
                {

                    if (events.Attendees.Select(a => a.Id).Contains(userId) == true)
                    {
                        TempData["Accepted"] = "Already";
                        return RedirectToAction("Index");
                    }

                    events.Attendees.Add(currentUser);
                    currentUser.Points = currentUser.Points + events.VolunteerValue;
                    events.EventCount = events.EventCount + 1;
                    TempData["Accepted"] = "Vol";
                }
            }

            if(currentPoints == currentUser.Points)
            {
                TempData["Accepted"] = "Not";
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ClubEvents([Bind(Include = "clubKey")] PointsViewModel key)
        {
            var userId = User.Identity.GetUserId();
            var currentUser = db.Users.Find(userId);
            var currentPoints = currentUser.Points;

            if (key.clubKey == null)
            {
                TempData["Accepted"] = "Nothing";
                return RedirectToAction("Index");
            }

            foreach (var events in db.clubEvents.ToList())
            {
                if (events.PointKey == key.clubKey)
                {

                    if (events.Attendees.Select(a => a.Id).Contains(userId) == true)
                    {
                        TempData["Accepted"] = "Already";
                        return RedirectToAction("Index");
                    }

                    if(events.ClubId != currentUser.ClubsId)
                    {
                        TempData["Accepted"] = "NotIn";
                        return RedirectToAction("Index");
                    }

                    events.Attendees.Add(currentUser);
                    currentUser.Points = currentUser.Points + events.PointValue;
                    events.EventCount = events.EventCount + 1;
                    TempData["Accepted"] = "Acc";
                }
            }

            if (currentPoints == currentUser.Points)
            {
                TempData["Accepted"] = "Not";
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}