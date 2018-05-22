using BookingSystem.BL.Infrastructure;
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
            NinjectModule repositoryModule = new RepositoryModule(connectionString);
            NinjectModule airportModule = new AirportModule();
            var kernel = new StandardKernel(repositoryModule, airportModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        private string GetConnectionString()
        {
            Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/BookingSystem.WebPL");
            ConnectionStringSettings cnnString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                cnnString = rootWebConfig.ConnectionStrings.ConnectionStrings["Connection1"];
                if (cnnString == null)
                {
                    throw new Exception("Connection string is null");
                }
            }
            else
            {
                throw new Exception("Does not any connection strings");
            }
            return cnnString.ConnectionString;
        }
    }
}
