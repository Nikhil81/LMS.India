using LMS.India.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace LMS.India.Repository
{
    public class GenericRepository<T> :
    ILMSRepository<T> where T : class
    {
        public DbContext _context;
        public DbSet<T> _dbset;
        public GenericRepository(DbContext context)
        {
            this._context = context;
            _dbset = context.Set<T>();
        }
        public void Add(T item)
        {
            //_con
        }

        public T Find(long key)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(long key)
        {
            // context.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(T item)
        {
            //context.Entry(item).State = EntityState.Modified;
        }
    }
}
