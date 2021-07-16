using System;
using System.Collections.Generic;
using System.Linq;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T GetById(Guid Id)
        {
            return entities.SingleOrDefault(s => s.Id == Id);
        }
        public T Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            context.SaveChanges();
            return entity;
        }
        public T Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            context.SaveChanges();
            return entity;
        }
        public void Delete(Guid Id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == Id);
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
