using BookingSystem.BL.Interfaces;
using BookingSystem.DAL.Domain;
using BookingSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BookingSystem.BL.Services
{
    public class AirportService : IAirportService
    {
        private IUnitOfWork unitOfWork;

        public AirportService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public Airport Get(int id)
        {
            Airport airport = unitOfWork.Airports.Get(id);
            if(airport == null)
            {
                throw new Exception($"Airport with id = {id} not found");
            }
            return airport;
        }

        public IEnumerable<Airport> GetAll()
        {
            return unitOfWork.Airports.GetAll();
        }

        public void Save(int id, string name, string address, string country)
        {
            Airport airport = unitOfWork.Airports.Get(id);
            if(airport != null)
            {
                throw new Exception($"Airport with id = {id} already exists");
            }
            unitOfWork.Airports.Add(new Airport(id, name, address, country));
            unitOfWork.Save();
        }

        public void Edit(int id, string name, string address, string country)
        {
            Airport airport = unitOfWork.Airports.Get(id);
            if (airport == null)
            {
                throw new Exception($"Airport with id = {id} not found");
            }
            Airport newAirport = new Airport(id, name, address, country);
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
