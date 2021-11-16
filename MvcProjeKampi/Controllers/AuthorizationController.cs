using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {

        AdminManager adminManager = new AdminManager(new EfAdminDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        AdminLoginManager adminLoginManager = new AdminLoginManager(new EfAdminDal());

       AdminValidator adminValidator = new AdminValidator();

        public ActionResult Index()
        {
            var adminvalues = adminManager.GetList();
            return View(adminvalues);
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
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminValue = adminManager.GetByID(id);
            List<SelectListItem> valueRole = (from x in roleManager.GetRoles()
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.RoleId.ToString()
                                              }).ToList();
            ViewBag.role = valueRole;
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            ValidationResult results = adminValidator.Validate(p);
            if (results.IsValid)
            {
                adminManager.AdminUpdate(p);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        public ActionResult DeleteAdmin(int id)
        {
            var adminvalue = adminManager.GetByID(id);
            adminvalue.AdminStatus =!adminvalue.AdminStatus;
            adminManager.AdminUpdate(adminvalue);
            return RedirectToAction("Index");
        }
    }
}