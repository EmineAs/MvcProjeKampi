using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutmanager = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var aboutvalues = aboutmanager.GetList();
            return View(aboutvalues);
        }

        public ActionResult AddAbout(About p)
        {
            aboutmanager.AboutAddBL(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}