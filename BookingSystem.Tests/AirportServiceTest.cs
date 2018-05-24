using BookingSystem.BL.Interfaces;
using BookingSystem.BL.Services;
using BookingSystem.DAL.EF.Models;
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
        private Mock<IRepository<Airport>> mockRepository;
        private Mock<IUnitOfWork> mockUow;
        private IAirportService airportService;

        public AirportServiceTest()
        {
            mockRepository = new Mock<IRepository<Airport>>();
            mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(m => m.Airports).Returns(mockRepository.Object);
            airportService = new AirportService(mockUow.Object);
        }

        [Test]
        public void GetAll_ShouldReturnsCorrectCountOfAirports()
        {
            mockRepository.Setup(m => m.GetAll()).Returns(new List<Airport>()
            {
                new Airport(1, "airport1", "address1", "country1"),
                new Airport(2, "airport2", "address2", "country2"),
                new Airport(3, "airport3", "address3", "country3")
            });
            var airports = airportService.GetAll();
            Assert.AreEqual(3, airports.Count());
        }

        [Test]
        public void Get_GivenCorrectId_ShouldReturnsAirport()
        {
            int airportId = 1;
            string airportName = "airport1";
            mockRepository.Setup(m => m.Get(airportId)).Returns(new Airport(airportId, airportName, "address1", "country1"));
            var airport = airportService.Get(airportId);
            Assert.AreEqual(airportName, airport.Name);
        }

        [Test]
        public void Get_GivenNonExistentId_ThrowsAnException()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(() => null);
            Assert.Throws<Exception>(() => airportService.Get(-1));
        }

        [Test]
        public void Save_GivenExistentAirportId_ThrowsAnException()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(new Airport(1, "airport1", "address1", "country1"));
            Assert.Throws<Exception>(() => airportService.Save(1, "airport", "address", "country"));
        }

        [Test]
        public void Save_GivenNonExistentId_ShouldInvokeAddInRepository()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(() => null);
            airportService.Save(1, "airport", "address", "country");
            mockRepository.Verify(m => m.Add(It.IsAny<Airport>()), Times.Once);
        }

        [Test]
        public void Edit_GivenNonExistentAirportId_ThrowsAnException()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(() => null);
            Assert.Throws<Exception>(() => airportService.Edit(1, "airport", "address", "country"));
        }

        [Test]
        public void Edit_GivenExistentAirportId_ShouldInvokeUpdateInRepository()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(new Airport(1, "airport", "address", "country"));
            airportService.Edit(1, "newAirport", "address", "country");
            mockRepository.Verify(m => m.Update(It.IsAny<Airport>()), Times.Once);
        }

        [Test]
        public void Delete_GivenNonExistentAirportId_ThrowsAnException()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(() => null);
            Assert.Throws<Exception>(() => airportService.Delete(1));
        }

        [Test]
        public void Delete_GivenExistentAirportId_ShouldInvokeRemoveInRepository()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(new Airport(1, "airport", "address", "country"));
            int airportId = 1;
            airportService.Delete(airportId);
            mockRepository.Verify(m => m.Remove(airportId), Times.Once);
        }
    }
}
