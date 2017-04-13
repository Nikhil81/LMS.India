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
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Find(long key);
        void Remove(long key);
        void Update(T item);
    }
}
