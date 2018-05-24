using System.Collections.Generic;

namespace BookingSystem.DAL.EF.Models
{
    public class Airport
    {
        public int AirportId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public Airport()
        {
            Flights = new List<Flight>();
        }
    }
}
