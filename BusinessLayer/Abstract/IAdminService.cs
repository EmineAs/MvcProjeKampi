﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();

        Admin GetAdmin(string username, string password);

        void AdminAddBL(Admin admin);

        //string GetSalt(string data);

        void AdminDelete(Admin admin);

        void AdminUpdate(Admin admin);
    }
}
