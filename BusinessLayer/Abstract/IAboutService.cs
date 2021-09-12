using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();

        void CategoryAddBL(Category about);

        Category GetByID(int id);

        void CategoryDelete(Category about);

        void CategoryUpdate(Category about);
    }
}
