using BookingSystem.BL.Interfaces;
using BookingSystem.BL.Services;
using BookingSystem.BL.Util;
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
        private Mock<IEventListener> mockEventListener;
        private IAirportService airportService;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IRepository<Airport>>();
            mockUow = new Mock<IUnitOfWork>();
            mockEventListener = new Mock<IEventListener>();
            mockUow.Setup(m => m.AirportRepository).Returns(mockRepository.Object);
            airportService = new AirportService(mockUow.Object, mockEventListener.Object);
        }

        [TearDown]
        public void Teardown()
        {
            mockRepository = null;
            mockUow = null;
            mockEventListener = null;
            airportService = null;
        }

        [Test]
        public void GetAll_ShouldReturnsCorrectCountOfAirports()
        {
            mockRepository.Setup(m => m.GetAll()).Returns(new List<Airport>()
            {
                new Airport{ AirportId = 1, Name = "airport1", Address = "address1", Country = "country1" },
                new Airport{ AirportId = 2, Name = "airport2", Address = "address2", Country = "country2" },
                new Airport{ AirportId = 3, Name = "airport3", Address = "address3", Country = "country3" }
            });
            var airports = airportService.GetAll();
            Assert.AreEqual(3, airports.Count());
        }

        [Test]
        public void Get_GivenCorrectId_ShouldReturnsAirport()
        {
            int airportId = 1;
            string airportName = "airport1";
            mockRepository.Setup(m => m.Get(airportId)).Returns(
                new Airport { AirportId = airportId, Name = airportName, Address = "address1", Country = "country1" });
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
        public void Save_GivenCorrectData_ShoudInvokeUpdateInEventListener()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(() => null);
            airportService.Save(1, "airport", "address", "country");
            mockEventListener.Verify(m => m.Update(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Save_GivenExistentAirportId_ThrowsAnException()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(
                new Airport { AirportId = 1, Name = "airport1", Address = "address1", Country = "country1" });
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
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(
                new Airport { AirportId = 1, Name = "airport1", Address = "address1", Country = "country1" });
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
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(
                new Airport { AirportId = 1, Name = "airport1", Address = "address1", Country = "country1" });
            int airportId = 1;
            airportService.Delete(airportId);
            mockRepository.Verify(m => m.Remove(airportId), Times.Once);
        }
    }
}
