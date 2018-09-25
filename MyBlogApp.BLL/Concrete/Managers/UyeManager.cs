using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MyBlogApp.DataAccess.EntityFramework.Abstract;
using MyBlogApp.Entities.Concrete;
using MyBlogApp.Entities.Web.SelectList;
using MyBlogApp.Interfaces;

namespace MyBlogApp.BLL.Concrete.Managers
{
    public class UyeManager
        : IUyeService
    {
        private readonly IUyeDal _uyeDal;
        public UyeManager(IUyeDal uyeDal)
        {
            _uyeDal = uyeDal;
        }

        public void Add(Uye uye)
        {
            _uyeDal.Add(uye);
        }

        public void Delete(Uye uye)
        {
            _uyeDal.Delete(uye);
        }

        public void Delete(int id)
        {
            _uyeDal.Delete(_uyeDal.Get(x => x.Id == id));
        }

        public Uye Get(int id, bool isInclude)
        {
            if (isInclude)
            {
                Expression<Func<Uye, object>>[] includes = new Expression<Func<Uye, object>>[2];
                includes[0] = x => x.Yetki;
                return _uyeDal.Get(x => x.Id == id, includes: includes);
            }

            return _uyeDal.Get(x => x.Id == id);
        }

        public List<Uye> GetAll(bool isInclude)
        {
            if (isInclude)
            {
                Expression<Func<Uye, object>>[] includes = new Expression<Func<Uye, object>>[2];
                includes[0] = x => x.Yetki;
                return _uyeDal.GetList(includes: includes);
            }

            return _uyeDal.GetList();
        }

        public List<UyeSelectList> GetUyeSelectList()
        {
            //Buraya daha sonra tekrar gel
            var uyeList = _uyeDal.GetList();
            return (from uye in uyeList
                    select new UyeSelectList
                    {
                        UyeId = uye.Id,
                        KullaniciAdi = uye.KullaniciAdi
                    }).ToList();
        }

        public void Update(Uye uye)
        {
            _uyeDal.Update(uye);
        }

        public int UyeSayisi()
        {
            return _uyeDal.Count();
        }
    }
}
