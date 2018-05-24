using System;
using System.Collections.Generic;

namespace BookingSystem.DAL.EF.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime BookingDate { get; set; }
        public string PassengerSurname { get; set; }
        public string PassengerName { get; set; }
        public string PassportNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public Order()
        {
            Flights = new List<Flight>();
        }
    }
}
