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

        public List<Message> GetListInBox(string mail)
        {
            return _messageDal.List(x => x.ReceiverMail == mail && x.MessageStatus == true);

        }

        public List<Message> GetListSendBox(string mail)
        {

            return _messageDal.List(x => x.SenderMail == mail && x.Draft == false && x.MessageStatus == true);
        }

        public List<Message> GetListDraftBox(string mail)
        {
            return _messageDal.List(x => x.SenderMail == mail && x.Draft == true && x.MessageStatus == true);
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

        public List<Message> GetListReadMessages(string mail)
        {
            return _messageDal.List(x => x.ReceiverMail == mail && x.Read == true && x.MessageStatus == true);

        }

        public List<Message> GetListUnReadMessages(string mail)
        {
            return _messageDal.List(x => x.ReceiverMail == mail && x.Read == false && x.MessageStatus == true);
        }

        public List<Message> GetListTrashBox(string mail)
        {
            return _messageDal.List(x => (x.ReceiverMail == mail || x.SenderMail == mail) && x.MessageStatus == false);
        }

        public void MessageDeleteAll(Message message)
        {
            _messageDal.Delete(message);
        }

    }
}
