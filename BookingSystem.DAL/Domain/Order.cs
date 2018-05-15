using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public string PassengerSurname { get; set; }
        public string PassengerName { get; set; }
        public string PassportNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Flight> Flights { get; set; }

        public Order(DateTime bookingDate, string passengerSurname, string passengerName, string passportNumber,
            string phoneNumber, string email, decimal totalPrice)
        {
            BookingDate = bookingDate;
            PassengerSurname = passengerSurname;
            PassengerName = passengerName;
            PassportNumber = passportNumber;
            PhoneNumber = phoneNumber;
            Email = email;
            TotalPrice = totalPrice;
            Flights = new List<Flight>();
        }

        public void AddFlight(Flight flight)
        {
            Flights.Add(flight);
        }
    }
}
