using System.Collections.Generic;

namespace SeriesRegister.Interfaces
{
    public interface IRepository<T>
    {
         List<T> list();
         T getById(int id);
         void insert(T entity);
         void delete(int id);
         void update(int id, T entity);
         int nextId();
    }
}