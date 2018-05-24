using System.Collections.Generic;

namespace BookingSystem.BL.DTO
{
    public class AirportDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public IEnumerable<FlightDTO> Flights { get; set; }
    }
}
