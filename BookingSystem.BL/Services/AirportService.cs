using BookingSystem.BL.Interfaces;
using BookingSystem.DAL.Domain;
using BookingSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BookingSystem.BL.Services
{
    public class AirportService : IAirportService
    {
        private IRepository<Airport> _airportRepository;

        public AirportService(IRepository<Airport> airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public void Delete(int id)
        {
            Airport airport = _airportRepository.Get(id);
            if (airport == null)
            {
                throw new Exception($"Airport with id = {id} not found");
            }
            _airportRepository.Remove(id);
        }

        public void Edit(int id, string name, string address, string country)
        {
            Airport airport = _airportRepository.Get(id);
            if (airport == null)
            {
                throw new Exception($"Airport with id = {id} not found");
            }
            Airport newAirport = new Airport(id, name, address, country);
            _airportRepository.Update(newAirport);
        }

        public Airport Get(int id)
        {
            Airport airport = _airportRepository.Get(id);
            if(airport == null)
            {
                throw new Exception($"Airport with id = {id} not found");
            }
            return airport;
        }

        public IEnumerable<Airport> GetAll()
        {
            return _airportRepository.GetAll();
        }

        public void Save(int id, string name, string address, string country)
        {
            Airport airport = _airportRepository.Get(id);
            if(airport != null)
            {
                throw new Exception($"Airport with id = {id} already exists");
            }
            _airportRepository.Add(new Airport(id, name, address, country));
        }
    }
}
