using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistic
        Context c = new Context();
        public int id;
        public ActionResult Index()
        {
            var countCategory = c.Categories.Count();

            var countHeading = c.Headings.Where(x => x.Category.CategoryName == "Yazılım").Count();

            var countWriter = c.Writers.Where(x => x.WriterName.Contains("a")).Count();

            var countCategoryTrue = c.Categories.Where(x => x.CategoryStatus == true).Count();

            var countCategoryFalse = c.Categories.Where(x => x.CategoryStatus == false).Count();

            var trueFalseDif = countCategoryTrue - countCategoryFalse;

            var countCategoryList = c.Headings.GroupBy(x => x.CategoryID).Select(y => new { y.Key, Count = y.Count() }).ToList();

            
            int max = 0;

            foreach (var items in countCategoryList)
            {
                if (items.Count > max)
                {
                    max = items.Count;
                    id = items.Key;
                }

               
            }

            var categoryName = c.Categories.Where(x => x.CategoryID == id).Select(y => y.CategoryName).FirstOrDefault();

            ViewBag.countCategory = countCategory;
            ViewBag.countHeading = countHeading;
            ViewBag.countWriter = countWriter;
            ViewBag.categoryName = categoryName;
            ViewBag.trueFalseDif = trueFalseDif;

            return View("Index");
        }
    }
}