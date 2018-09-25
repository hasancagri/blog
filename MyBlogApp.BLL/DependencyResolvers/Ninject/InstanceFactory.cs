using Ninject;

namespace MyBlogApp.BLL.DependencyResolvers.Ninject
{
    public static class InstanceFactory<T>
    {
        public static T GetInstance()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}
