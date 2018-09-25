using MyBlogApp.Core.DataAccess.Concrete;
using MyBlogApp.DataAccess.EntityFramework.Abstract;
using MyBlogApp.Entities.Concrete;
using MyBlogApp.MSSQL.DataAccess.EntityFramework.Concrete.Contexts;

namespace MyBlogApp.MSSQL.DataAccess.EntityFramework.Concrete
{
    public class EfEtiketDal
        : EntityRepositoryBase<Etiket, MyBlogAppContext>, IEtiketDal
    {
    }
}
