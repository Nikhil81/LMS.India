using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LMS.India.Repository
{
    public interface ILMSRepository<T> where T : class
    {
        void Add(T item);
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll(params string[] includeProperties);
        T Find(long key);
        void Remove(long key);
        void Update(T item);
    }
}
