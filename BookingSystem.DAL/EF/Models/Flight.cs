using System;

namespace BookingSystem.DAL.EF.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public Airport DeparturePoint { get; set; }
        public Airport ArrivalPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }

        public int AirportId { get; set; }
        public Airport Airport { get; set; }
    }
}