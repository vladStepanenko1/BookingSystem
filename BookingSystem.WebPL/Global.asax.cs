using BookingSystem.BL.Infrastructure;
using BookingSystem.BL.Util;
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

            NinjectModule serviceModule = new ServiceModule();
            NinjectModule airportModule = new AirportModule();
            //NinjectModule decoratorModule = new DecoratorModule();
            NinjectModule eventListenerModule = new EventListenerModule();

            var kernel = new StandardKernel(serviceModule, airportModule, eventListenerModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
