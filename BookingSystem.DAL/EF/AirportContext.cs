using BookingSystem.DAL.EF.Models;
using System.Data.Entity;

namespace BookingSystem.DAL.EF
{
    public class AirportContext : DbContext
    {
        public DbSet<Airport> Airports { get; set; }

        static AirportContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        public AirportContext(string connectionString) : base(connectionString)
        {
        }
    }
}
