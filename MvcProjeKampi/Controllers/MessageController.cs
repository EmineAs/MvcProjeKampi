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
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult DeleteMessage(int id)
        {
            var messagevalue = messageManager.GetByID(id);
            messageManager.MessageDelete(messagevalue);
            return RedirectToAction("Index", "Contact");
        }

        public ActionResult DeleteMessageAll(int id)
        {
            var messagevalue = messageManager.GetByID(id);
            messageManager.MessageDeleteAll(messagevalue);
            return RedirectToAction("Index", "Contact");
        }
        public ActionResult Sendbox()
        {
            string mail = (string)Session["AdminMail"];
            var messageList = messageManager.GetListSendBox(mail);
            return View(messageList);
        }

        public ActionResult Draftbox()
        {
            string mail = (string)Session["AdminMail"];
            var messageList = messageManager.GetListDraftBox(mail);
            return View(messageList);
        }

        public ActionResult Trashbox()
        {
            string mail = (string)Session["AdminMail"];
            var messageList = messageManager.GetListTrashBox(mail);
            return View(messageList);
        }


        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult NewMessage(Message message, string menu)
        {
            string session = (string)Session["AdminMail"];

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
                    return RedirectToAction("Index", "Contact");
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
                    return RedirectToAction("Index", "Contact");
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
                return RedirectToAction("Index", "Contact");
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

    }
}