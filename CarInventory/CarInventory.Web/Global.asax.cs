﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarInventory.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
            log4net.Config.XmlConfigurator.Configure();            
        }
    }
}
