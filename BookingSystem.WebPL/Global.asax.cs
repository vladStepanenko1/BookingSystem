﻿using BookingSystem.BL.Infrastructure;
using BookingSystem.Web.Util;
using Ninject;
using Ninject.Modules;
using System;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookingSystem.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string connectionString = GetConnectionString();
            NinjectModule serviceModule = new ServiceModule(connectionString);
            NinjectModule airportModule = new AirportModule();
            var kernel = new StandardKernel(serviceModule, airportModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        private string GetConnectionString()
        {
            Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/BookingSystem.WebPL");
            ConnectionStringSettings cnnStringObject = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                cnnStringObject = rootWebConfig.ConnectionStrings.ConnectionStrings["Connection1"];
                if (cnnStringObject == null)
                {
                    throw new Exception("Connection string is null");
                }
            }
            else
            {
                throw new Exception("Does not any connection strings");
            }
            return cnnStringObject.ConnectionString;
        }
    }
}
