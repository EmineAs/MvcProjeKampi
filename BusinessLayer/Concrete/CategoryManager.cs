using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager 
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();
       

        public void CategoryAddBL(Category p)
        {
            if(p.CategoryName=="" || p.CategoryName.Length<=3 || p.CategoryDescription=="" || p.CategoryName.Length >= 51)
            {
                //hatamesajı
            }
            else
            {
                repo.Insert(p);
            }


        }

        

        public List<Category> GetAll()
        {
            return repo.List();
        }


    }
}
