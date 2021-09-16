using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}