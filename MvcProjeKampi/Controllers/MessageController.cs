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

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInBox();
            return View(messageList);
        }

        public ActionResult ReadMessages()
        {
            var messageList = messageManager.GetListReadMessages();
            return View("Inbox",messageList);
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
                p.SenderMail = "admin@gmail.com";
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                //p.Draft = false;
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

        public ActionResult GetMessageDetail(int id)
        {
            var messagevalue = messageManager.GetByID(id);
            messagevalue.Read = true;
            messageManager.MessageUpdate(messagevalue);
            return View(messagevalue);
        }
        public ActionResult AddDraftMessage(Message p)
        {
            p.SenderMail = "admin@gmail.com";
            p.Draft = true;
            p.MessageDate = DateTime.Now;
            messageManager.MessageAddDraftBL(p);
            return RedirectToAction("Inbox");

        }

       
    }
}