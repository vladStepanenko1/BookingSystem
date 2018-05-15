using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Domain
{
    public class Flight
    {
        public int Id { get; set; }
        public Airport DeparturePoint { get; set; }
        public Airport ArrivalPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }

        public Flight(Airport departurePoint, Airport arrivalPoint, DateTime departureTime, DateTime arrivalTime, decimal price)
        {
            DeparturePoint = departurePoint;
            ArrivalPoint = arrivalPoint;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Price = price;
        }
    }
}
