﻿using MyBlogApp.Admin.MvcWebUI.Infrastuctures;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyBlogApp.Admin.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
