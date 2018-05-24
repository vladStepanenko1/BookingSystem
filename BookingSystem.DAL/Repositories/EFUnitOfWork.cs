using BookingSystem.DAL.Domain;
using BookingSystem.DAL.EF;
using BookingSystem.DAL.Interfaces;

namespace BookingSystem.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AirportContext db;
        private EFAirportRepository airportRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new AirportContext(connectionString);
        }

        public IRepository<Airport> Airports
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
