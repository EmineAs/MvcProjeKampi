﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RegisterManager : IRegisterService
    {
        IWriterDal _writerDal;

        public RegisterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetWriterMail(string mail)
        {
            return _writerDal.Get(x => x.WriterMail == mail);
        }
    }
}
