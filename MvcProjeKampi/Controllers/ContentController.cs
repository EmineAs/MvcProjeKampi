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
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            //var contentvalues = cm.GetListByHeadingID(id);
            //var headerName=cm.
            //ViewBag.headerName = headerName;
            //return View(contentvalues);
            return View();

        }
    }
}