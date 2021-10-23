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

        AdminLoginManager adminLoginManager = new AdminLoginManager(new EfAdminDal());
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valueRole = (from x in roleManager.GetRoles()
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.RoleId.ToString()
                                              }).ToList();
            ViewBag.role = valueRole;
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            p.AdminPassword = adminLoginManager.GetHash(p.AdminPassword);
            adminManager.AdminAddBL(p);
            return View();
        }
    }
}