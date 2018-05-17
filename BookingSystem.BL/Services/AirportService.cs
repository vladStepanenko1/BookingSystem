using BookingSystem.BL.Interfaces;
using BookingSystem.DAL.Domain;
using BookingSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void Edit(int id, string name, string address, string country)
        {
            throw new NotImplementedException();
        }

        public Airport Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Airport> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(int id, string name, string address, string country)
        {
            throw new NotImplementedException();
        }
    }
}
