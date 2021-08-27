using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();

        void HeadingAddBL(Heading heading);

        Heading GetByID(int id);

        void HeadingDelete(Heading heading);

        void HeadingUpdate(Heading heading);

    }
}
