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
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        public ActionResult MyContent()
        {
            int id=(int)Session["WriterID"];
            var contentvalues = contentManager.GetListByWriter(id);
            return View(contentvalues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            var headingvalues = headingManager.GetByID(id);
            TempData["headingname"] = headingvalues.HeadingName;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content, int id)
        {
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID= (int)Session["WriterID"];
            content.ContentStatus = true;
            content.HeadingID = id;
            contentManager.ContentAddBL(content);
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = contentManager.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}