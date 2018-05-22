using BookingSystem.DAL.Domain;
using BookingSystem.DAL.Interfaces;
using BookingSystem.DAL.Repositories;
using Ninject.Modules;

namespace BookingSystem.BL.Infrastructure
{
    public class RepositoryModule : NinjectModule
    {
        private string connectionString;

        public RepositoryModule(string connString)
        {
            connectionString = connString;
        }

        public override void Load()
        {
            Bind<IRepository<Airport>>().To<AdoNetAirportRepository>().WithConstructorArgument(connectionString);
        }
    }
}
