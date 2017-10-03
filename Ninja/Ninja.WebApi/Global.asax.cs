﻿using Ninja.WebApi.App_Start;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ninja.WebApi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            
            //Mapper
            Ninja.Repository.AutoMapperConfig.MapperConfiguration.RegisterMaps();

            GlobalConfiguration.Configuration.EnsureInitialized(); 
        }
    }
}
