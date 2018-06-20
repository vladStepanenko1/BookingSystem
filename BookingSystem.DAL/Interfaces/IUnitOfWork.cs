using BookingSystem.DAL.EF.Models;

namespace BookingSystem.DAL.Interfaces
{
    /// <summary>
    /// The interface for UnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Retrieves AirportRepository
        /// </summary>
        IRepository<Airport> AirportRepository { get; }

        /// <summary>
        /// Executes SaveChanges() in data context
        /// </summary>
        void Save();
    }
}
