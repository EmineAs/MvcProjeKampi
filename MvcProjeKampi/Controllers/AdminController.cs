using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        AdminManager adminManager = new AdminManager(new EfAdminDal());


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            p.AdminMail = adminManager.GetHash(p.AdminMail);
            p.AdminPassword = adminManager.GetHash(p.AdminPassword);

            adminManager.AdminAddBL(p);
            return View();

        }
    }
}