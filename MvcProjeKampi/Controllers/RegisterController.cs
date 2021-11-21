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
    [AllowAnonymous]

    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();


        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterRegister(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);

            if (results.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterImage = "/AdminLTE-3.0.4/dist/img/2.png";
                writer.WriterTittle = "Üye";
                writerManager.WriterAddBL(writer);
                return RedirectToAction("WriterLogIn", "LogIn");
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
    }
}
