using BookingSystem.BL.Interfaces;
using BookingSystem.BL.Services;
using BookingSystem.DAL.Domain;
using BookingSystem.DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [Test]
        public void Get_GivenNonExistentId_ThrowsAnException()
        {
            var mockRepository = new Mock<IRepository<Airport>>();
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(() => null);
            IAirportService airportService = new AirportService(mockRepository.Object);
            Assert.Throws<Exception>(() => airportService.Get(-1));
        }

        [Test]
        public void Save_GivenExistentAirportId_ThrowsAnException()
        {
            var mockRepository = new Mock<IRepository<Airport>>();
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(new Airport(1, "airport1", "address1", "country1"));
            IAirportService airportService = new AirportService(mockRepository.Object);
            Assert.Throws<Exception>(() => airportService.Save(1, "airport", "address", "country"));
        }

        [Test]
        public void Save_GivenNonExistentId_ShouldInvokeAddInRepository()
        {
            var mockRepository = new Mock<IRepository<Airport>>();
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(() => null);
            IAirportService airportService = new AirportService(mockRepository.Object);
            airportService.Save(1, "airport", "address", "country");
            mockRepository.Verify(m => m.Add(It.IsAny<Airport>()), Times.Once);
        }

        [Test]
        public void Edit_GivenNonExistentAirportId_ThrowsAnException()
        {
            var mockRepository = new Mock<IRepository<Airport>>();
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(() => null);
            IAirportService airportService = new AirportService(mockRepository.Object);
            Assert.Throws<Exception>(() => airportService.Edit(1, "airport", "address", "country"));
        }

        [Test]
        public void Edit_GivenExistentAirportId_ShouldInvokeUpdateInRepository()
        {
            var mockRepository = new Mock<IRepository<Airport>>();
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(new Airport(1, "airport", "address", "country"));
            IAirportService airportService = new AirportService(mockRepository.Object);
            airportService.Edit(1, "newAirport", "address", "country");
            mockRepository.Verify(m => m.Update(It.IsAny<Airport>()), Times.Once);
        }

        [Test]
        public void Delete_GivenNonExistentAirportId_ThrowsAnException()
        {
            var mockRepository = new Mock<IRepository<Airport>>();
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(() => null);
            IAirportService airportService = new AirportService(mockRepository.Object);
            Assert.Throws<Exception>(() => airportService.Delete(1));
        }

        [Test]
        public void Delete_GivenExistentAirportId_ShouldInvokeRemoveInRepository()
        {
            var mockRepository = new Mock<IRepository<Airport>>();
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(new Airport(1, "airport", "address", "country"));
            IAirportService airportService = new AirportService(mockRepository.Object);
            int airportId = 1;
            airportService.Delete(airportId);
            mockRepository.Verify(m => m.Remove(airportId), Times.Once);
        }
    }
}
