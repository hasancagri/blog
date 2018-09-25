using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MyBlogApp.DataAccess.EntityFramework.Abstract;
using MyBlogApp.Entities.Concrete;
using MyBlogApp.Interfaces;

namespace MyBlogApp.BLL.Concrete.Managers
{
    public class YorumManager
        : IYorumService
    {
        private readonly IYorumDal _yorumDal;
        public YorumManager(IYorumDal yorumDal)
        {
            _yorumDal = yorumDal;
        }

        public void Add(Yorum yorum)
        {
            //Burası daha sonra değişecek
            _yorumDal.Add(yorum);
        }

        public void Delete(int id)
        {
            _yorumDal.Delete(Get(id, true));
        }

        public void Delete(Yorum yorum)
        {
            _yorumDal.Delete(yorum);
        }

        public Yorum Get(int id, bool isInclude)
        {
            if (isInclude)
            {
                Expression<Func<Yorum, object>>[] includes = new Expression<Func<Yorum, object>>[2];
                includes[0] = x => x.Makale;
                includes[1] = x => x.Uye;
                return _yorumDal.Get(includes: includes);
            }

            return _yorumDal.Get(x => x.Id == id);
        }

        public List<Yorum> GetAll(bool isInclude)
        {
            if (isInclude)
            {
                Expression<Func<Yorum, object>>[] includes = new Expression<Func<Yorum, object>>[2];
                includes[0] = x => x.Makale;
                includes[1] = x => x.Uye;
                return _yorumDal.GetList(includes: includes);
            }

            return _yorumDal.GetList();
        }

        public List<Yorum> SonYorumlar()
        {
            //Buraya daha sonra tekrar gel
            return _yorumDal.GetList().Take(5).ToList();
        }

        public void Update(Yorum yorum)
        {
            _yorumDal.Update(yorum);
        }

        public int YorumSayisi()
        {
            return _yorumDal.Count();
        }
    }
}
