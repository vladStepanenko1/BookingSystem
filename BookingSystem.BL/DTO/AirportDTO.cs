using System.Collections.Generic;

namespace BookingSystem.BL.DTO
{
    /// <summary>
    /// Data Transfer Object for Airport entity
    /// </summary>
    public class AirportDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public IEnumerable<FlightDTO> Flights { get; set; }
    }
}
