using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class EventController : Controller
    {
        private readonly ExamEntities1 db = new ExamEntities1();
        public ActionResult Index()
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            List<Event> events = db.Events.Where(e => e.UserId == UserId && e.IsDeleted == 0).ToList();
            return View(events);
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            Event e = db.Events.Find(id);

            if (e == null)
            {
                ViewBag.Error = "No event found.";
                return RedirectToAction("Index", "Event");
            }
            return View(e);
        }

        public ActionResult CreateEventItem()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event e)
        {
            if (!ModelState.IsValid)
            {
                return View(e);
            }
            if (!db.Events.Any(ev => ev.EventDate == e.EventDate))
            {
                e.CreatedOn = DateTime.Now;
                e.UpdatedOn = DateTime.Now;
                e.CreatedBy = Convert.ToInt32(Session["UserId"]);
                e.UserId = Convert.ToInt32(Session["UserId"]);
                e.IsDeleted = 0;

                db.Events.Add(e);
                db.SaveChanges();
                return RedirectToAction("Index", "Event");
            }
            else
            {
                switch (e.Duration.ToLower())
                {
                    case "firsthalf":
                        if (db.Events.Any(ev => ev.EventDate == e.EventDate && ev.Duration == "firsthalf"))
                        {
                            ViewBag.Error = "You already have an event.";
                            return View(e);
                        }
                        else
                        {
                            e.CreatedOn = DateTime.Now;
                            e.UpdatedOn = DateTime.Now;
                            e.CreatedBy = Convert.ToInt32(Session["UserId"]);
                            e.UserId = Convert.ToInt32(Session["UserId"]);
                            e.IsDeleted = 0;

                            db.Events.Add(e);
                            db.SaveChanges();
                            return RedirectToAction("Index", "Event");
                        }
                    case "secondhalf":
                        if (db.Events.Any(ev => ev.EventDate == e.EventDate && ev.Duration == "secondhalf"))
                        {
                            ViewBag.Error = "You already have an event.";
                            return View(e);
                        }
                        else
                        {
                            e.CreatedOn = DateTime.Now;
                            e.UpdatedOn = DateTime.Now;
                            e.CreatedBy = Convert.ToInt32(Session["UserId"]);
                            e.UserId = Convert.ToInt32(Session["UserId"]);
                            e.IsDeleted = 0;

                            db.Events.Add(e);
                            db.SaveChanges();
                            return RedirectToAction("Index", "Event");
                        }
                    default:
                        ViewBag.Error = "You already have an event.";
                        return View(e);

                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event e)
        {
            if (!ModelState.IsValid)
            {
                return View(e);
            }

            if (!db.Events.Any(ev => ev.EventDate == e.EventDate))
            {
                Event existingEvent = db.Events.Find(e.EventId);

                existingEvent.UpdatedOn = DateTime.Now;
                existingEvent.QtyOfDishes = e.QtyOfDishes;
                existingEvent.Duration = e.Duration;
                existingEvent.EventDate = e.EventDate;

                db.SaveChanges();
                return RedirectToAction("Index", "Event");
            }
            else
            {
                switch (e.Duration.ToLower())
                {
                    case "firsthalf":
                        if (db.Events.Any(ev => ev.EventDate == e.EventDate && ev.Duration == "firsthalf"))
                        {
                            ViewBag.Error = "You already have an event.";
                            return View(e);
                        }
                        else
                        {
                            Event existingEvent = db.Events.Find(e.EventId);

                            existingEvent.UpdatedOn = DateTime.Now;
                            existingEvent.QtyOfDishes = e.QtyOfDishes;
                            existingEvent.Duration = e.Duration;
                            existingEvent.EventDate = e.EventDate;

                            db.SaveChanges();
                            return RedirectToAction("Index", "Event");
                        }
                    case "secondhalf":
                        if (db.Events.Any(ev => ev.EventDate == e.EventDate && ev.Duration == "secondhalf"))
                        {
                            ViewBag.Error = "You already have an event.";
                            return View(e);
                        }
                        else
                        {
                            Event existingEvent = db.Events.Find(e.EventId);

                            existingEvent.UpdatedOn = DateTime.Now;
                            existingEvent.QtyOfDishes = e.QtyOfDishes;
                            existingEvent.Duration = e.Duration;
                            existingEvent.EventDate = e.EventDate;

                            db.SaveChanges();
                            return RedirectToAction("Index", "Event");
                        }
                    default:
                        ViewBag.Error = "You already have an event.";
                        return View(e);

                }
            }

        }
        public ActionResult Delete(int id)
        {
            Event e = db.Events.Find(id);
            if (e == null)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            try
            {
                //db.Events.Remove(e);
                //db.SaveChanges();

                e.IsDeleted = 1;
                db.SaveChanges();

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new { success = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
