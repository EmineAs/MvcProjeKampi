using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellUrCar.Controllers
{
    [AllowAnonymous]
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

        public ActionResult DeleteContact(int id)
        {
            var contactvalue = contactManager.GetByID(id);
            contactvalue.ContactStatus = false;
            contactManager.ContactUpdate(contactvalue);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContactAll(int id)
        {
            var contactvalue = contactManager.GetByID(id);
            contactManager.ContactDelete(contactvalue);
            return RedirectToAction("Inbox");
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

            string mail = (string)Session["AdminMail"];
            var inboxvalues = messageManager.GetListInBox(mail);
            var countInbox = inboxvalues.Count();
            ViewBag.countInbox = countInbox;

            var readvalues = messageManager.GetListReadMessages(mail);
            var countRead = readvalues.Count();
            ViewBag.countRead = countRead;

            var unreadvalues = messageManager.GetListUnReadMessages(mail);
            var countUnRead = unreadvalues.Count();
            ViewBag.countUnRead = countUnRead;

            var sendboxvalues = messageManager.GetListSendBox(mail);
            var countSendbox = sendboxvalues.Count();
            ViewBag.countSendbox = countSendbox;

            var draftboxvalues = messageManager.GetListDraftBox(mail);
            var countDraftbox = draftboxvalues.Count();
            ViewBag.countDraftbox = countDraftbox;

            var trashboxvalues = messageManager.GetListTrashBox(mail);
            var countTrashbox = trashboxvalues.Count();
            ViewBag.countTrashbox = countTrashbox;

            return PartialView();
        }
    }
}