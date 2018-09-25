using MyBlogApp.DataAccess.EntityFramework.Abstract;
using MyBlogApp.Entities.Concrete;
using MyBlogApp.Interfaces;

namespace MyBlogApp.BLL.Concrete.Managers
{
    public class EtiketManager
        : IEtiketService
    {
        private readonly IEtiketDal _etiketDal;
        public EtiketManager(IEtiketDal etiketDal)
        {
            _etiketDal = etiketDal;
        }

        public void Add(Etiket etiket)
        {
            _etiketDal.Add(etiket);
        }

        public void Delete(Etiket etiket)
        {
            _etiketDal.Add(etiket);
        }
    }
}
