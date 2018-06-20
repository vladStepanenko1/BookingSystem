using BookingSystem.BL.Util;
using Ninject.Modules;

namespace BookingSystem.BL.Infrastructure
{
    public class EventListenerModule : NinjectModule
    {
        private string logFilePath = @"C:\Users\vlad\Documents\Visual Studio 2017\Projects\BookingSystem\BookingSystem.BL/log.txt";

        public override void Load()
        {
            Bind<IEventListener>().To<LogEventListener>().WithConstructorArgument(logFilePath);
        }
    }
}
