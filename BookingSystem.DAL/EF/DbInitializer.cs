using BookingSystem.DAL.EF.Models;
using System.Data.Entity;

namespace BookingSystem.DAL.EF
{
    /// <summary>
    /// The database initializer
    /// </summary>
    public class DbInitializer : DropCreateDatabaseAlways<AirportContext>
    {
        /// <summary>
        /// Initializes db context with specified objects
        /// </summary>
        /// <param name="context">Object which represents data context. Derived from DbContext</param>
        protected override void Seed(AirportContext context)
        {
            context.Airports.Add(new Airport { Name = "Airport1", Address = "Address1", Country = "Country1" });
            context.Airports.Add(new Airport { Name = "Airport2", Address = "Address2", Country = "Country2" });
            context.Airports.Add(new Airport { Name = "Airport3", Address = "Address3", Country = "Country3" });
            context.SaveChanges();
        }
    }
}