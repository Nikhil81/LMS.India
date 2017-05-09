using DataModel.Data.Context;
using DataModel.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.Repository.RepositoryClass
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private WebApiDBContext _context;
        internal DbSet<T> dbSet;
        public GenericRepository(WebApiDBContext context)
        {
            _context = context;
            this.dbSet = context.Set<T>();
        }
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query;
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }
    }
}
