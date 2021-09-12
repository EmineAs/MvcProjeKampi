using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();

        void AboutAddBL(About About);

        About GetByID(int id);

        void AboutDelete(About About);

        void AboutUpdate(About About);

    }
}
