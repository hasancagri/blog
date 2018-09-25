using MyBlogApp.BLL.DependencyResolvers.Ninject;
using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyBlogApp.Admin.MvcWebUI.Infrastuctures
{
    public class NinjectControllerFactory
        : DefaultControllerFactory
    {
        private readonly IKernel _kernel;
        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel(new BusinessModule());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.TryGet(controllerType);
        }
    }
}