using BookingSystem.DAL.EF.Models;

namespace BookingSystem.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Airport> Airports { get; }
        void Save();
    }
}
