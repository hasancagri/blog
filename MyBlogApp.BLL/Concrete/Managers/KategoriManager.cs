using MyBlogApp.DataAccess.EntityFramework.Abstract;
using MyBlogApp.Entities.Concrete;
using MyBlogApp.Entities.Web.SelectList;
using MyBlogApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyBlogApp.BLL.Concrete.Managers
{
    public class KategoriManager
        : IKategoriService
    {
        private readonly IKategoriDal _kategoriDal;
        public KategoriManager(IKategoriDal kategoriDal)
        {
            _kategoriDal = kategoriDal;
        }

        public void Add(Kategori kategori)
        {
            _kategoriDal.Add(kategori);
        }

        public void Delete(Kategori kategori)
        {
            _kategoriDal.Delete(kategori);
        }

        public Kategori Get(int id, bool isInclude)
        {
            if (isInclude)
            {
                Expression<Func<Kategori, object>>[] includes = new Expression<Func<Kategori, object>>[1];
                includes[0] = x => x.Makaleler;
                return _kategoriDal.Get(includes: includes);
            }
            return _kategoriDal.Get();
        }

        public List<Kategori> GetAllKategori(bool isInclude)
        {
            if (isInclude)
            {
                Expression<Func<Kategori, object>>[] includes = new Expression<Func<Kategori, object>>[1];
                includes[0] = x => x.Makaleler;
                return _kategoriDal.GetList(includes: includes);
            }
            return _kategoriDal.GetList();
        }

        public List<KategoriSelectList> GetKategoriSelectList()
        {
            //Buraya daha sonra tekrar gel
            var kategoriList = _kategoriDal.GetList();
            return (from kategori in kategoriList
                    select new KategoriSelectList
                    {
                        KategoriId = kategori.Id,
                        KategoriAdi = kategori.KategoriAdi
                    }).ToList();
        }

        public int KategoriSayisi()
        {
            return _kategoriDal.Count();
        }

        public void Update(Kategori kategori)
        {
            _kategoriDal.Update(kategori);
        }
    }
}
