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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAddBL(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public string GetHash(string data)
        {
            
            byte[] dataarray = ASCIIEncoding.ASCII.GetBytes(data);
            string hashedname = Convert.ToBase64String(dataarray);
            return hashedname;
        }
    }
}
