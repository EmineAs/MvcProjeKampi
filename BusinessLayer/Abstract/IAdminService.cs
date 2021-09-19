using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        //List<Admin> GetList();

        //List<Admin> GetActiveList();

        void AdminAddBL(Admin admin);

        //Admin GetByID(int id);

        string GetHash(string data);

        void AdminDelete(Admin admin);

        void AdminUpdate(Admin admin);
    }
}
