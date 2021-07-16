using System;
using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(Guid id);
    }
}
