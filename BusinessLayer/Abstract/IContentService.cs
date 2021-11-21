using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetList(string p);
        List<Content> GetListByHeadingID(int id, string p);
        List<Content> GetListByHeadingID(int id);
        List<Content> GetListByWriter(int id);
        List<Content> GetListByWriter(int id,string p);
        void ContentAddBL(Content content);
        Content GetByID(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
    }
}
