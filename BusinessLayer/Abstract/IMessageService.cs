using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInBox(string mail);
        List<Message> GetListSendBox(string mail);
        List<Message> GetListDraftBox(string mail);
        List<Message> GetListReadMessages(string mail);
        List<Message> GetListUnReadMessages(string mail);
        List<Message> GetListTrashBox(string mail);
        void MessageAddBL(Message message);
        Message GetByID(int id);
        void MessageDelete(Message message);
        void MessageDeleteAll(Message message);
        void MessageUpdate(Message message);
    }
}
