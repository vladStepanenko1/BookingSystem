﻿using BookingSystem.BL.DTO;
using BookingSystem.BL.Interfaces;
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

        public AirportService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public AirportDTO Get(int id)
        {
            Airport airport = unitOfWork.Airports.Get(id);
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
            return unitOfWork.Airports.GetAll().Select(x => new AirportDTO
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
            Airport airport = unitOfWork.Airports.Get(id);
            if(airport != null)
            {
                throw new Exception($"Airport with id = {id} already exists");
            }
            unitOfWork.Airports.Add(new Airport { AirportId = id, Name = name, Address = address, Country = country });
            unitOfWork.Save();
        }

        public void Edit(int id, string name, string address, string country)
        {
            Airport airport = unitOfWork.Airports.Get(id);
            if (airport == null)
            {
                throw new Exception($"Airport with id = {id} not found");
            }
            Airport newAirport = new Airport { AirportId = id, Address = address, Name = name, Country = country };
            unitOfWork.Airports.Update(newAirport);
            unitOfWork.Save();
        }

        public void Delete(int id)
        {
            Airport airport = unitOfWork.Airports.Get(id);
            if (airport == null)
            {
                throw new Exception($"Airport with id = {id} not found");
            }
            unitOfWork.Airports.Remove(id);
            unitOfWork.Save();
        }
    }
}
