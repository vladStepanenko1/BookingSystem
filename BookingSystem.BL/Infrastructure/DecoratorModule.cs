using BookingSystem.BL.Interfaces;
using BookingSystem.BL.Services;
using Ninject.Modules;

namespace BookingSystem.BL.Infrastructure
{
    public class DecoratorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAirportService>().To<AirportService>().WhenInjectedInto<AirportServiceWithLogger>();
        }
    }
}
