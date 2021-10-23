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
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterDal _WriterDal;

        public WriterLoginManager(IWriterDal WriterDal)
        {
            _WriterDal = WriterDal;
        }

        public Writer GetWriter(string Writername, string password)
        {
            return _WriterDal.Get(x => x.WriterMail == Writername && x.WritePassWord == password);
        }
    }
}
