using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        WriterValidator writerValidator = new WriterValidator();

        [HttpGet]
        public ActionResult WriterProfile()
        {
            int id = (int)Session["WriterID"];
            var writervalue = writerManager.GetByID(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.WriterUpdate(writer);
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("MyHeading");
        }

        public ActionResult MyHeading()
        {
            int id = (int)Session["WriterID"];
            var values = headingManager.GetListByWriter(id);
            return View(values);
        }

        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = (int)Session["WriterID"];
            heading.HeadingStatus = true;
            headingManager.HeadingAddBL(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var headingvalue = headingManager.GetByID(id);
            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = headingManager.GetByID(id);
            headingvalue.HeadingStatus = !headingvalue.HeadingStatus;
            headingManager.HeadingUpdate(headingvalue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int page=1)
        {
            var headinglist = headingManager.GetList().ToPagedList(page,4);
            return View(headinglist);
        }

    }
}