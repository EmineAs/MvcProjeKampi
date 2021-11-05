using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            }); 
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });

            return categoryClasses;
        }

        public ActionResult LineChart()
        {
            return View();
        }

        public ActionResult HeadingChart()
        {
            return Json(HeadList(), JsonRequestBehavior.AllowGet);
        }

        public List<HeadingClass> HeadList()
        {
            var values = headingManager.GetList().GroupBy(x=>x.Category.CategoryName);
            List<HeadingClass> headingClasses = new List<HeadingClass>();
            headingClasses = values.Select(x => new HeadingClass
            {
                CategoryName = x.Key,
                HeadingCount = x.Count()
            }).ToList();
            return headingClasses;
        }

        public ActionResult ColumnChart()
        {
            return View();
        }

        public ActionResult ContentChart()
        {
            return Json(ContentList(), JsonRequestBehavior.AllowGet);
        }

        public List<ContentClass> ContentList()
        {
            var values = contentManager.GetList().GroupBy(x => x.Heading.HeadingName);
            List<ContentClass> contentClasses = new List<ContentClass>();
            contentClasses = values.Select(x => new ContentClass
            {
                HeadingName = x.Key,
                ContentCount = x.Count()
            }).ToList();
            return contentClasses;
        }
    }
}