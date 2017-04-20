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
        public EntityDBContext _context;
        private DbSet<T> _dbset;
        
        public GenericRepository(EntityDBContext context)
        {
            this._context = context;
            this._dbset = context.Set<T>(); //GetDbSet(context);
        }

        //private DbSet<T> GetDbSet(EntityDBContext context)
        //{
        //    throw new NotImplementedException();
        //}

        public void Add(T item)
        {
            //_con
            this._dbset.Add(item);
            Save();
        }

        public T Find(long key)
        {
           return  this._dbset.Find(key);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> _dbQuery = this._dbset;
            foreach (Expression<Func<T, object>> include in includes)
                _dbQuery = _dbQuery.Include(include);
            return _dbQuery;
        }

        //get multiple childs

        public IQueryable<T> GetAll(params string[] includeProperties)
        {
            IQueryable<T> _dbQuery = this._dbset;
            foreach (var includeProperty in includeProperties)
            {
                _dbQuery = _dbQuery.Include(includeProperty);
            }
            return _dbQuery;
        }

        

    public void Remove(long key)
        {
            // context.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(T item)
        {
            //context.Entry(item).State = EntityState.Modified;
        }
        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
