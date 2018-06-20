using System.Collections.Generic;

namespace BookingSystem.DAL.Interfaces
{
    /// <summary>
    /// The generic interface for repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Retrieves all entities from storage
        /// </summary>
        /// <returns>All entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Retrieves entity from storage by unique paramer
        /// </summary>
        /// <param name="id">Unique value for identifying entity</param>
        /// <returns>Entity by parameter</returns>
        T Get(int id);

        /// <summary>
        /// Adds specified entity to storage
        /// </summary>
        /// <param name="entity">Entity to adding</param>
        void Add(T entity);

        /// <summary>
        /// Updates specified entity in storage
        /// </summary>
        /// <param name="entity">Entity to update</param>
        void Update(T entity);

        /// <summary>
        /// Removes specified entity from storage
        /// </summary>
        /// <param name="id">Unique value for identifying entity</param>
        void Remove(int id);
    }
}
