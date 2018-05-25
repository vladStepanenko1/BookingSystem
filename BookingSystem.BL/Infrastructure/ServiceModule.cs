using BookingSystem.DAL.Interfaces;
using BookingSystem.DAL.Repositories;
using Ninject.Modules;

namespace BookingSystem.BL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}
