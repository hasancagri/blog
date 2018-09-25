using MyBlogApp.DataAccess.EntityFramework.Abstract;
using MyBlogApp.Entities.Web.SelectList;
using MyBlogApp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyBlogApp.BLL.Concrete.Managers
{
    public class YetkiManager
        : IYetkiService
    {
        private readonly IYetkiDal _yetkiDal;
        public YetkiManager(IYetkiDal yetkiDal)
        {
            _yetkiDal = yetkiDal;
        }

        public List<YetkiSelectList> GetYetkiSelectList()
        {
            //Buraya daha sonra tekrar gel
            var yetkiList = _yetkiDal.GetList();
            return (from yetki in yetkiList.ToList()
                    select new YetkiSelectList
                    {
                        YetkiId = yetki.Id,
                        YetkiAdi = yetki.YetkiAdi
                    }).ToList();
        }
    }
}
