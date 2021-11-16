using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());

        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            var values=cm.GetList();
            if (!string.IsNullOrEmpty(p))
            {
                values = cm.GetList(p);
            }
            return View(values);
        }

        public ActionResult ContentByHeading(int id,string p)
        {
            var contentvalues = cm.GetListByHeadingID(id);
            if (!string.IsNullOrEmpty(p))
            {
                contentvalues = cm.GetListByHeadingID(id,p);
            }
            var heading = headingManager.GetByID(id);
            ViewBag.heading = heading.HeadingName;
            return View(contentvalues);
        }
    }
}