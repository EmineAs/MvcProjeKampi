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
        List<Message> GetListInBox();
        List<Message> GetListSendBox();
        List<Message> GetListDraftBox();
        List<Message> GetListReadMessages();
        List<Message> GetListUnReadMessages();
       

        void MessageAddBL(Message message);

        Message GetByID(int id);

        void MessageDelete(Message message);

        void MessageUpdate(Message message);
    }
}
