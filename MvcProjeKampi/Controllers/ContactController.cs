using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalues = contactManager.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetail(int id)
        {
            var contactvalue = contactManager.GetByID(id);
            return View(contactvalue);
        }
        public PartialViewResult ContactPartial()
        {
            var contactvalues = contactManager.GetList();
            var countContact = contactvalues.Count();
            ViewBag.countContact = countContact;

            var inboxvalues = messageManager.GetListInBox();
            var countInbox = inboxvalues.Count();
            ViewBag.countInbox = countInbox;

            var sendboxvalues = messageManager.GetListSendBox();
            var countSendbox = sendboxvalues.Count();
            ViewBag.countSendbox = countSendbox;

            return PartialView();
        }
    }
}