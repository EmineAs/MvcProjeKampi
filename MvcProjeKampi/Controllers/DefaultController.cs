using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        // GET: Default
        public ActionResult Headings()
        {

            var headingvalues = headingManager.GetList();
            
            return View(headingvalues);
        }

        public PartialViewResult Index(int id = 0,string p="")
        {
            var contentlist = contentManager.GetListByHeadingID(id);
            var headingvalues = headingManager.GetByID(id);

            if (!string.IsNullOrEmpty(p))
            {
                contentlist = contentManager.GetListByHeadingID(id, p);
            }
            if (headingvalues != null)
            {
                if (contentlist.Count != 0)
                {
                    ViewBag.heading = headingvalues.HeadingName+" Başlığına ait içerikler";

                }
                else
                {
                    ViewBag.heading = headingvalues.HeadingName + " Başlığına ait içerik bulunamadı";
                }
            }
            else
            {
                ViewBag.heading = "İstediğiniz içeriğe ulaşmak için lütfen sol menüdeki başlıklara tıklayınız...";
            }
            return PartialView(contentlist);
        }
        public PartialViewResult Search()
        {
            return PartialView();
        }

        public PartialViewResult MessagePartial()
        {
            string mail = (string)Session["WriterMail"];
            var inboxvalues = messageManager.GetListInBox(mail);
            var countInbox = inboxvalues.Count();
            ViewBag.countInbox = countInbox;

            var messageList = messageManager.GetListInBox(mail);
            return PartialView(messageList);
        }

        public PartialViewResult WriterProfile(int id)
        {
            var writervalue = writerManager.GetByID(id);
            return PartialView(writervalue);
        }
    }
}