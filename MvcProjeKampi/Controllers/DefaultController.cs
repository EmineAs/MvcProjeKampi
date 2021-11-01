using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        // GET: Default
        public ActionResult Headings()
        {

            var headingvalues = headingManager.GetList();
            return View(headingvalues);
        }

        public PartialViewResult Index(int id=0)
        {
            var contentlist = contentManager.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}