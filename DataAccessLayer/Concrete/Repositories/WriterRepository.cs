﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.Repositories
{
    public class WriterRepository : IWriterDal
    {

        Context c = new Context();
        DbSet<Writer> _object;

        public void Delete(Writer p)
        {
            throw new NotImplementedException();
        }

        public void Delete(Heading p)
        {
            throw new NotImplementedException();
        }

        public Writer Get(Expression<Func<Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Heading Get(Expression<Func<Heading, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Writer p)
        {
            throw new NotImplementedException();
        }

        public void Insert(Heading p)
        {
            throw new NotImplementedException();
        }

        public List<Writer> List()
        {
            throw new NotImplementedException();
        }

        public List<Writer> List(Expression<Func<Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Heading> List(Expression<Func<Heading, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Writer p)
        {
            throw new NotImplementedException();
        }

        public void Update(Heading p)
        {
            throw new NotImplementedException();
        }

        List<Heading> IRepository<Heading>.List()
        {
            throw new NotImplementedException();
        }
    }
}