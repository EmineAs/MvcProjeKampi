using BusinessLayer.Concrete;
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
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        // GET: Skill
        public ActionResult Index()
        {
            var skillValues = skillManager.GetList(); //? işaretleri boş gelme/boş olma durumuna 
            return View(skillValues);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Skill p)
        {
            //ValidationResult results = writerValidator.Validate(p);
            //if (results.IsValid)
            //{
                skillManager.SkillAddBL(p);
                return RedirectToAction("Index");

            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();
        }

    }
}