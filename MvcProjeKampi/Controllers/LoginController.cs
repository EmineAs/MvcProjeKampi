using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        AdminLoginManager adminloginManager = new AdminLoginManager(new EfAdminDal());

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            string pass = adminloginManager.GetHash(p.AdminPassword);
            var adminuserinfo = adminloginManager.GetAdmin(p.AdminUserName, pass);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminMail, false);
                Session["AdminID"] = adminuserinfo.AdminID;
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                Session["AdminMail"] = adminuserinfo.AdminMail;
                return RedirectToAction("Index", "Heading");
            }
            else
            {
                return View();
            }
            

        }
    }
}