using BookingSystem.BL.DTO;
using BookingSystem.BL.Interfaces;
using BookingSystem.BL.Util;
using BookingSystem.DAL.EF.Models;
using BookingSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.BL.Services
{
    public class AirportService : IAirportService
    {
        private IUnitOfWork unitOfWork;
        private EventManager eventManager;
        private IEventListener _eventListener;

        public AirportService(IUnitOfWork uow, IEventListener eventListener)
        {
            unitOfWork = uow;
            _eventListener = eventListener;

            eventManager = new EventManager();
            eventManager.Subscribe(EventType.Saved, _eventListener);
            eventManager.Subscribe(EventType.Deleted, _eventListener);
        }

        public AirportDTO Get(int id)
        {
            Airport airport = unitOfWork.AirportRepository.Get(id);
            if(airport == null)
            {
                throw new Exception($"Airport with id = {id} not found");
            }

            return new AirportDTO
            {
                Id = airport.AirportId,
                Name = airport.Name,
                Address = airport.Address,
                Country = airport.Country
            };
        }

        public IEnumerable<AirportDTO> GetAll()
        {
            return unitOfWork.AirportRepository.GetAll().Select(x => new AirportDTO
            {
                Id = x.AirportId,
                Name = x.Name,
                Address = x.Address,
                Country = x.Country,
                Flights = x.Flights.Select(f => new FlightDTO
                {
                    Id = f.FlightId,
                    ArrivalPoint = new AirportDTO
                    {
                        Id = f.ArrivalPoint.AirportId,
                        Name = f.ArrivalPoint.Name,
                        Address = f.ArrivalPoint.Address,
                        Country = f.ArrivalPoint.Country,
                    },
                    DeparturePoint = new AirportDTO
                    {
                        Id = f.DeparturePoint.AirportId,
                        Name = f.DeparturePoint.Name,
                        Address = f.DeparturePoint.Address,
                        Country = f.DeparturePoint.Country,
                    },
                    ArrivalTime = f.ArrivalTime,
                    DepartureTime = f.DepartureTime,
                    Price = f.Price
                })
            });
        }

        public void Save(int id, string name, string address, string country)
        {
            Airport airport = unitOfWork.AirportRepository.Get(id);
            if(airport != null)
            {
                throw new Exception($"Airport with id = {id} already exists");
            }
            unitOfWork.AirportRepository.Add(new Airport { Name = name, Address = address, Country = country });
            unitOfWork.Save();

            eventManager.Notify(EventType.Saved, $"Airport with id = {id} saved");
        }

        public void Edit(int id, string name, string address, string country)
        {
            Airport airport = unitOfWork.AirportRepository.Get(id);
            if (airport == null)
            {
                throw new Exception($"Airport with id = {id} not found");
            }
            airport.Name = name;
            airport.Address = address;
            airport.Country = country;

            unitOfWork.AirportRepository.Update(airport);
            unitOfWork.Save();

            eventManager.Notify(EventType.Saved, $"Airport with id = {id} saved");
        }

        public void Delete(int id)
        {
            Airport airport = unitOfWork.AirportRepository.Get(id);
            if (airport == null)
            {
                throw new Exception($"Airport with id = {id} not found");
            }
            unitOfWork.AirportRepository.Remove(id);
            unitOfWork.Save();

            eventManager.Notify(EventType.Deleted, $"Airport with id = {id} deleted");
        }
    }
}
