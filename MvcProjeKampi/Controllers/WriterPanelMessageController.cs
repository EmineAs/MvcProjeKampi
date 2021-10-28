using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellUrCar.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInBox();
            return View(messageList);
        }

        public ActionResult ReadMessages()
        {
            var messageList = messageManager.GetListReadMessages();
            return View("Inbox", messageList);
        }

        public ActionResult UnReadMessages()
        {
            var messageList = messageManager.GetListUnReadMessages();
            return View("Inbox", messageList);
        }

        public ActionResult Sendbox()
        {
            var messageList = messageManager.GetListSendBox();
            return View(messageList);
        }

        public ActionResult Draftbox()
        {
            var messageList = messageManager.GetListDraftBox();
            return View(messageList);
        }

        public ActionResult Trashbox()
        {
            var messageList = messageManager.GetListTrashBox();
            return View(messageList);
        }

       
        [HttpGet]
        public ActionResult SendMessage(int id)
        {
            var writervalues = writerManager.GetByID(id);
            var mail = writervalues.WriterMail;
            ViewBag.mail = mail;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SendMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = (string)Session["writerMail"];
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.MessageStatus = true;
                p.Read = false;
                messageManager.MessageAddBL(p);
                return RedirectToAction("Inbox");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteMessage(int id)
        {
            var messagevalue = messageManager.GetByID(id);
            messageManager.MessageDelete(messagevalue);
            return RedirectToAction("Inbox");
        }

        public ActionResult DeleteMessageAll(int id)
        {
            var messagevalue = messageManager.GetByID(id);
            messageManager.MessageDeleteAll(messagevalue);
            return RedirectToAction("Inbox");
        }

        public ActionResult GetMessageDetail(int id)
        {
            var messagevalue = messageManager.GetByID(id);
            messagevalue.Read = true;
            messageManager.MessageUpdate(messagevalue);
            return View(messagevalue);
        }

        public PartialViewResult MessagePartial()
        {

            var inboxvalues = messageManager.GetListInBox();
            var countInbox = inboxvalues.Count();
            ViewBag.countInbox = countInbox;

            var readvalues = messageManager.GetListReadMessages();
            var countRead = readvalues.Count();
            ViewBag.countRead = countRead;

            var unreadvalues = messageManager.GetListUnReadMessages();
            var countUnRead = unreadvalues.Count();
            ViewBag.countUnRead = countUnRead;

            var sendboxvalues = messageManager.GetListSendBox();
            var countSendbox = sendboxvalues.Count();
            ViewBag.countSendbox = countSendbox;

            var draftboxvalues = messageManager.GetListDraftBox();
            var countDraftbox = draftboxvalues.Count();
            ViewBag.countDraftbox = countDraftbox;

            var trashboxvalues = messageManager.GetListTrashBox();
            var countTrashbox = trashboxvalues.Count();
            ViewBag.countTrashbox = countTrashbox;

            return PartialView();
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)] //content açılmıyordu ekledim sonra buraya dönecem

        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);

            if (results.IsValid)
            {
                p.SenderMail = "gizem@hotmail.com";
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.MessageStatus = true;
                p.Read = false;
                messageManager.MessageAddBL(p);
                return RedirectToAction("Sendbox");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}