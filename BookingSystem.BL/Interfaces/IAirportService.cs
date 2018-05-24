using BookingSystem.BL.DTO;
using System.Collections.Generic;

namespace BookingSystem.BL.Interfaces
{
    public interface IAirportService
    {
        void Save(int id, string name, string address, string country);
        AirportDTO Get(int id);
        IEnumerable<AirportDTO> GetAll();
        void Edit(int id, string name, string address, string country);
        void Delete(int id);
    }
}
