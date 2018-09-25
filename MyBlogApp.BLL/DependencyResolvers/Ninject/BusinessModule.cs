using MyBlogApp.BLL.Concrete.Managers;
using MyBlogApp.DataAccess.EntityFramework.Abstract;
using MyBlogApp.Interfaces;
using MyBlogApp.MSSQL.DataAccess.EntityFramework.Concrete;
using Ninject.Modules;

namespace MyBlogApp.BLL.DependencyResolvers.Ninject
{
    public class BusinessModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<IYorumService>().To<YorumManager>();
            Bind<IYorumDal>().To<EfYorumDal>();
            Bind<IMakaleService>().To<MakaleManager>();
            Bind<IMakaleDal>().To<EfMakaleDal>();
            Bind<IEtiketService>().To<EtiketManager>();
            Bind<IEtiketDal>().To<EfEtiketDal>();
            Bind<IUyeService>().To<UyeManager>();
            Bind<IUyeDal>().To<EfUyeDal>();
            Bind<IKategoriService>().To<KategoriManager>();
            Bind<IKategoriDal>().To<EfKategoriDal>();
        }
    }
}
