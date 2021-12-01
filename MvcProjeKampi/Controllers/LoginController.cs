using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcProjeKampi.Models;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminLoginManager adminloginManager = new AdminLoginManager(new EfAdminDal());
        WriterLoginManager writerloginManager = new WriterLoginManager(new EfWriterDal());

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

        [HttpGet]
        public ActionResult WriterLogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogIn(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);

            var writerinfo = writerloginManager.GetWriter(writer.WriterMail, writer.WriterPassWord);

            //var response = Request["g-recaptcha-response"];
            //const string secret = "6LdVp2wdAAAAAPToM0BDOFfQDOXgw3BrQPnpvm2R";
            //var client = new WebClient();
            //var reply =
            //    client.DownloadString(
            //        string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            //var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

          
                if (writerinfo != null /*&& captchaResponse.Success*/)
                {
                    FormsAuthentication.SetAuthCookie(writerinfo.WriterName, false);
                    Session["WriterID"] = writerinfo.WriterID;
                    Session["WriterMail"] = writerinfo.WriterMail;
                    Session["WriterName"] = writerinfo.WriterName;
                    Session["WriterSurName"] = writerinfo.WriterSurName;
                    Session["WriterImage"] = writerinfo.WriterImage;
                    return RedirectToAction("MyContent", "WriterPanelContent");
                }
                else
                {
                    return View();
                }
            
        }

        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "LogIn");
        }

        public ActionResult WriterLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}

