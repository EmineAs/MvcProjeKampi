using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());

        public ActionResult MyContent(string p)
        {
            int id=(int)Session["WriterID"];
            var contentvalues = contentManager.GetListByWriter(id);
            if (!string.IsNullOrEmpty(p))
            {
                contentvalues = contentManager.GetListByWriter(id, p);
            }
            return View(contentvalues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            var headingvalues = headingManager.GetByID(id);
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content, int id)
        {
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID= (int)Session["WriterID"];
            content.ContentStatus = true;
            content.HeadingID = id;
            if(content.ContentValue!=null)
            {
                contentManager.ContentAddBL(content);
            }
            return View();
        }

        public PartialViewResult ContentByHeadingPartial(int id, string p)
        {
            var contentvalues = contentManager.GetListByHeadingID(id);
            if (!string.IsNullOrEmpty(p))
            {
                contentvalues = contentManager.GetListByHeadingID(id, p);
            }
            var heading = headingManager.GetByID(id);
            ViewBag.heading = heading.HeadingName;
            return PartialView(contentvalues);
        }

        public ActionResult ContentByHeading(int id, string p)
        {
            var contentvalues = contentManager.GetListByHeadingID(id);
            if (!string.IsNullOrEmpty(p))
            {
                contentvalues = contentManager.GetListByHeadingID(id, p);
            }
            var heading = headingManager.GetByID(id);
            ViewBag.heading = heading.HeadingName;
            return View(contentvalues);
        }

        public PartialViewResult Search()
        {
            return PartialView();
        }
    }
}