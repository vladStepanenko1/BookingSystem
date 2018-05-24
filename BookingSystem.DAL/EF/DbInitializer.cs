using BookingSystem.DAL.Domain;
using System.Data.Entity;

namespace BookingSystem.DAL.EF
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<AirportContext>
    {
        protected override void Seed(AirportContext context)
        {
            context.Airports.Add(new Airport(1, "Airport1", "Address1", "Country1"));
            context.Airports.Add(new Airport(2, "Airport2", "Address2", "Country2"));
            context.Airports.Add(new Airport(3, "Airport3", "Address3", "Country3"));
            context.SaveChanges();
        }
    }
}