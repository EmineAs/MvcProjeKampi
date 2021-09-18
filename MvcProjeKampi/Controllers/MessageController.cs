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

        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInBox();
            return View(messageList);
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
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);
            
            if (results.IsValid)
            {
                p.SenderMail = "admin@gmail.com";
                p.MessageDate = DateTime.Now;
                p.Draft = false;
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

        public ActionResult AddMessage(Message p)
        {
            p.SenderMail = "admin@gmail.com";
            p.Draft = false;
            p.MessageDate = DateTime.Now;

            messageManager.MessageAddBL(p);
            return RedirectToAction("Inbox");

        }
    }
}