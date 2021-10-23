using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}