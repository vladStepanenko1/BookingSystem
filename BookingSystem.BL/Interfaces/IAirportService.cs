using BookingSystem.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.BL.Interfaces
{
    public interface IAirportService
    {
        void Save(int id, string name, string address, string country);
        Airport Get(int id);
        IEnumerable<Airport> GetAll();
        void Edit(int id, string name, string address, string country);
        void Delete(int id);
    }
}
