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

        public Admin GetAdmin(string username, string password)
        {
            return _adminDal.Get(x => x.AdminUserName == username && x.AdminPassword == password);
        }

        

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }

        //public string GetSalt(string data)
        //{
        //    byte[] dataarray = Convert.FromBase64String(data);
        //    string saltedname = ASCIIEncoding.ASCII.GetString(dataarray);
        //    return saltedname;
        //}
    }
}
