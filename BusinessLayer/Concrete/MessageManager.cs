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
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInBox()
        {
            return _messageDal.List(x => x.ReceiverMail == "gizem@hotmail.com" && x.MessageStatus == true);

        }

        public List<Message> GetListSendBox()
        {
            return _messageDal.List(x => x.SenderMail == "gizem@hotmail.com" && x.Draft == false && x.MessageStatus == true);
        }

        public List<Message> GetListDraftBox()
        {
            return _messageDal.List(x => x.SenderMail == "gizem@hotmail.com" && x.Draft == true && x.MessageStatus == true);
        }

        public void MessageAddBL(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageAddDraftBL(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            message.MessageStatus = false;
            _messageDal.Update(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public List<Message> GetListReadMessages()
        {
            return _messageDal.List(x => x.ReceiverMail == "gizem@hotmail.com" && x.Read == true && x.MessageStatus == true);
        }

        public List<Message> GetListUnReadMessages()
        {
            return _messageDal.List(x => x.ReceiverMail == "gizem@hotmail.com" && x.Read == false && x.MessageStatus == true);
        }

        public List<Message> GetListTrashBox()
        {
            return _messageDal.List(x => (x.ReceiverMail == "gizem@hotmail.com" || x.SenderMail == "gizem@hotmail.com") && x.MessageStatus == false);
        }

        public void MessageDeleteAll(Message message)
        {
            _messageDal.Delete(message);
        }
    }
}
