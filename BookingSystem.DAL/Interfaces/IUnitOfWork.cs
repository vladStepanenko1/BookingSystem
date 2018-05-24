using BookingSystem.DAL.Domain;

namespace BookingSystem.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Airport> Airports { get; }
        void Save();
    }
}
