using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;

namespace BookingSystem.Web.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private StandardKernel kernel;

        public NinjectDependencyResolver(StandardKernel kernelParam)
        {
            kernel = kernelParam;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}