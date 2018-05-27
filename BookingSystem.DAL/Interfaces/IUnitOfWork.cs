using BookingSystem.DAL.EF.Models;

namespace BookingSystem.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Airport> AirportRepository { get; }
        void Save();
    }
}
