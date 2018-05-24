using System.Collections.Generic;

namespace BookingSystem.DAL.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
    }
}
