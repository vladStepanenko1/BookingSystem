using BookingSystem.BL.Interfaces;
using BookingSystem.BL.Services;
using BookingSystem.DAL.Domain;
using BookingSystem.DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Tests
{
    [TestFixture]
    public class AirportServiceTest
    {
        [Test]
        public void GetAll_ShouldReturnsCorrectCountOfAirports()
        {
            var mockRepository = new Mock<IRepository<Airport>>();
            mockRepository.Setup(m => m.GetAll()).Returns(new List<Airport>()
            {
                new Airport(1, "airport1", "address1", "country1"),
                new Airport(2, "airport2", "address2", "country2"),
                new Airport(3, "airport3", "address3", "country3")
            });
            IAirportService airportService = new AirportService(mockRepository.Object);
            var airports = airportService.GetAll();
            Assert.AreEqual(3, airports.Count());
        }

        [Test]
        public void Get_GivenCorrectId_ShouldReturnsAirport()
        {
            var mockRepository = new Mock<IRepository<Airport>>();
            int airportId = 1;
            string airportName = "airport1";
            mockRepository.Setup(m => m.Get(airportId)).Returns(new Airport(airportId, airportName, "address1", "country1"));
            IAirportService airportService = new AirportService(mockRepository.Object);
            var airport = airportService.Get(airportId);
            Assert.AreEqual(airportName, airport.Name);
        }
    }
}
