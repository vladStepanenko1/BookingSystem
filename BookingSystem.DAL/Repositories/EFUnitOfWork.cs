using BookingSystem.DAL.EF.Models;
using BookingSystem.DAL.EF;
using BookingSystem.DAL.Interfaces;

namespace BookingSystem.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AirportContext db;
        private EFAirportRepository airportRepository;

        public EFUnitOfWork()
        {
            db = new AirportContext();
        }

        public IRepository<Airport> AirportRepository
        {
            get
            {
                if(airportRepository == null)
                {
                    airportRepository = new EFAirportRepository(db);
                }
                return airportRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
