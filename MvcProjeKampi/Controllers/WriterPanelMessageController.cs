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
            string mail = (string)Session["WriterMail"];
            var messageList = messageManager.GetListInBox(mail);
            return View(messageList);
        }

        public ActionResult ReadMessages()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = messageManager.GetListReadMessages(mail);
            return View("Inbox", messageList);
        }

        public ActionResult UnReadMessages()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = messageManager.GetListUnReadMessages(mail);
            return View("Inbox", messageList);
        }

        public ActionResult Sendbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = messageManager.GetListSendBox(mail);
            return View(messageList);
        }

        public ActionResult Draftbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = messageManager.GetListDraftBox(mail);
            return View(messageList);
        }

        public ActionResult Trashbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = messageManager.GetListTrashBox(mail);
            return View(messageList);
        }

        [HttpGet]
        public ActionResult WriterMessage(int id)
        {
            var writervalue = writerManager.GetByID(id);
            var mail = writervalue.WriterMail;
            ViewBag.mail = mail;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult WriterMessage(Message message, string menu)
        {
            string session = (string)Session["WriterMail"];

            ValidationResult results = messagevalidator.Validate(message);

            //Yeni Mesaj sayfasındaki buton isimlerine göre kontroller aşagıdaki gibi yapılır

            //Eğer kullanıcı Gönder tuşuna basarsa;
            if (menu == "send")
            {
                if (results.IsValid)
                {
                    message.SenderMail = session;
                    message.MessageStatus = true;
                    message.Read = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAddBL(message);
                    return RedirectToAction("Inbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            //Eğer kullanıcı Taslaklara Kaydet tuşuna basarsa;
            else if (menu == "draft")
            {
                if (results.IsValid)
                {
                    message.SenderMail = session;
                    message.Draft = true;
                    message.MessageStatus = true;
                    message.Read = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAddBL(message);
                    return RedirectToAction("Inbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            //Eğer kullanıcı İptal tuşuna basarsa;
            else if (menu == "cancel")
            {
                return RedirectToAction("Inbox");
            }
            return View();
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult NewMessage(Message message, string menu)
        {
            string session = (string)Session["WriterMail"];

            ValidationResult results = messagevalidator.Validate(message);

            //Yeni Mesaj sayfasındaki buton isimlerine göre kontroller aşagıdaki gibi yapılır

            //Eğer kullanıcı Gönder tuşuna basarsa;
            if (menu == "send")
            {
                if (results.IsValid)
                {
                    message.SenderMail = session;
                    message.MessageStatus = true;
                    message.Read = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAddBL(message);
                    return RedirectToAction("Inbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            //Eğer kullanıcı Taslaklara Kaydet tuşuna basarsa;
            else if (menu == "draft")
            {
                if (results.IsValid)
                {
                    message.SenderMail = session;
                    message.Draft = true;
                    message.MessageStatus = true;
                    message.Read = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAddBL(message);
                    return RedirectToAction("Inbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            //Eğer kullanıcı İptal tuşuna basarsa;
            else if (menu == "cancel")
            {
                return RedirectToAction("Inbox");
            }
            return View();
        }

        [HttpGet]
        public ActionResult SendMessage(int id)
        {
            var Writervalues = writerManager.GetByID(id);
            var mail = Writervalues.WriterMail;
            ViewBag.mail = mail;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SendMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = (string)Session["WriterMail"];
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
            string mail = (string)Session["WriterMail"];

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