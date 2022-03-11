using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]

    public class CalendarController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        //
        // GET: /Calendar/

        [HttpGet]
        public ActionResult Index()
        {
            return View(new CalendarEvent());
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var events = new List<CalendarEvent>();
           

            foreach (var item in headingManager.GetList())
            {
                events.Add(new CalendarEvent()
                {
                    title = item.HeadingName,
                    start = item.HeadingDate,
                    allDay = true
                });

               
            }

            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }

    }
}