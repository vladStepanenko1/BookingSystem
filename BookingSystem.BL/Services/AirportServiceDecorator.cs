using BookingSystem.BL.DTO;
using BookingSystem.BL.Interfaces;
using System.Collections.Generic;

namespace BookingSystem.BL.Services
{
    public class AirportServiceDecorator : IAirportService
    {
        private IAirportService service;

        public AirportServiceDecorator(IAirportService airportService)
        {
            service = airportService;
        }

        public virtual void Delete(int id)
        {
            service.Delete(id);
        }

        public virtual void Edit(int id, string name, string address, string country)
        {
            service.Edit(id, name, address, country);
        }

        public virtual AirportDTO Get(int id)
        {
            return service.Get(id);
        }

        public virtual IEnumerable<AirportDTO> GetAll()
        {
            return service.GetAll();
        }

        public virtual void Save(int id, string name, string address, string country)
        {
            service.Save(id, name, address, country);
        }
    }
}
