using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public ActionResult Index(int? page)
        {
            var headingvalues = headingManager.GetList().ToPagedList(page ?? 1,7);
            return View(headingvalues);
        }

        public ActionResult HeadingReport()
        {
            var headingvalues = headingManager.GetList();
            return View(headingvalues);
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = headingManager.GetByID(id);
            headingvalue.HeadingStatus = !headingvalue.HeadingStatus;
            headingManager.HeadingUpdate(headingvalue);
            return RedirectToAction("Index");
        }

    }
}