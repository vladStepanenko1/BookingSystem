using BookingSystem.DAL.Interfaces;
using BookingSystem.DAL.Repositories;
using Ninject.Modules;

namespace BookingSystem.BL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connString)
        {
            connectionString = connString;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
