using BookingSystem.BL.Interfaces;
using BookingSystem.BL.Services;
using Ninject.Modules;

namespace BookingSystem.Web.Util
{
    public class AirportModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAirportService>().To<AirportService>();
        }
    }
}