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
    public class MakaleManager
        : IMakaleService
    {
        //Burada daha sonra try-catch olacak
        private readonly IMakaleDal _makaleDal;
        public MakaleManager(IMakaleDal makaleDal)
        {
            _makaleDal = makaleDal;
        }

        public List<Makale> BlogAra(string Ara = null)
        {
            //Burayı daha sonra değiştir
            Expression<Func<Makale, object>>[] includes = new Expression<Func<Makale, object>>[3];
            includes[0] = x => x.Etiketler;
            includes[1] = x => x.Uye;
            includes[2] = x => x.Kategori;
            return _makaleDal.GetList(filter: x => x.Baslik.ToLower().Contains(Ara.ToLower()));
        }

        public void Delete(Makale makale)
        {
            _makaleDal.Delete(makale);
        }

        public List<Makale> GetAll(bool isInclude)
        {
            if (isInclude)
            {
                Expression<Func<Makale, object>>[] includes = new Expression<Func<Makale, object>>[3];
                includes[0] = x => x.Etiketler;
                includes[1] = x => x.Uye;
                includes[2] = x => x.Kategori;
                return _makaleDal.GetList(includes: includes);
            }

            return _makaleDal.GetList();
        }

        public Makale GetMakale(int id, bool isInclude)
        {
            if (isInclude)
            {
                Expression<Func<Makale, object>>[] includes = new Expression<Func<Makale, object>>[3];
                includes[0] = x => x.Etiketler;
                includes[1] = x => x.Uye;
                includes[2] = x => x.Kategori.Makaleler;
                return _makaleDal.Get(x => x.Id == id, includes: includes);
            }
            return _makaleDal.Get(x => x.Id == id);
        }

        public List<MakaleSelectList> GetMakaleSelectList()
        {
            //Buraya daha sonra tekrar gel
            var makaleList = _makaleDal.GetList();
            return (from makale in makaleList
                    select new MakaleSelectList
                    {
                        MakaleId = makale.Id,
                        Baslik = makale.Baslik
                    }).ToList();
        }

        public List<Makale> KategorininMakalesi(int kategoriId)
        {
            //Buraya daha sonra tekrar gel
            var entity = _makaleDal.GetList(x => x.Kategori.Id == kategoriId);
            return entity;
        }

        public int MakaleSayisi()
        {
            return _makaleDal.Count();
        }

        public void OkunmaArttir(int id, int quantity)
        {
            //Burayı daha sonra değiştir
            var entity = GetMakale(id, false);
            entity.Okunma += quantity;
            _makaleDal.Update(entity);
        }

        public List<Makale> PopulerMakaleler()
        {
            //Buraya daha sonra tekrar gel
            return _makaleDal.GetList().Take(5).ToList();
        }

        public void Update(Makale makale)
        {
            _makaleDal.Update(makale);
        }
    }
}
