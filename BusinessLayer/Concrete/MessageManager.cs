using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetListInBox()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com");
        }

        public List<Message> GetListSendBox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com"&& x.Draft==false);
        }

        public List<Message> GetListDraftBox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com" && x.Draft == true);
        }

        public void MessageAddBL(Message message)
        {
            message.Draft = false;
            _messageDal.Insert(message);
        }

        public void MessageAddDraftBL(Message message)
        {
            message.Draft = true;
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
