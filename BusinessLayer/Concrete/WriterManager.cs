using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void WriterAddBL( Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete( Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate( Writer writer)
        {
            _writerDal.Update(writer);
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public List<Writer> GetListActive()
        {
            return _writerDal.List(x => x.WriterStatus == true);
        }

        public List<Writer> GetListPassive()
        {
            return _writerDal.List(x => x.WriterStatus == false);
        }
    }
}
