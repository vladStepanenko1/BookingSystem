﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Domain
{
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public List<Flight> Flights { get; set; }

        public Airport(string name, string address, string country)
        {
            Name = name;
            Address = address;
            Country = country;
            Flights = new List<Flight>();
        }

        public void AddFlight(Airport departure, Airport arrival, DateTime departureTime, 
            DateTime arrivalTime, decimal price)
        {
            Flight flight = new Flight(departure, arrival, departureTime, arrivalTime, price);
            Flights.Add(flight);
        }
    }
}
