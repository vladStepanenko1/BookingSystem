using System;

namespace BookingSystem.BL.DTO
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public AirportDTO DeparturePoint { get; set; }
        public AirportDTO ArrivalPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
    }
}