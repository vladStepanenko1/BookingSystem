using BookingSystem.DAL.Domain;
using BookingSystem.DAL.EF;
using BookingSystem.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookingSystem.DAL.Repositories
{
    public class EFAirportRepository : IRepository<Airport>
    {
        private AirportContext db;

        public EFAirportRepository(AirportContext context)
        {
            db = context;
        }

        public void Add(Airport entity)
        {
            db.Airports.Add(entity);
        }

        public Airport Get(int id)
        {
            return db.Airports.Find(id);
        }

        public IEnumerable<Airport> GetAll()
        {
            return db.Airports;
        }

        public void Remove(int id)
        {
            Airport airport = Get(id);
            if(airport != null)
            {
                db.Airports.Remove(airport);
            }
        }

        public void Update(Airport entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
