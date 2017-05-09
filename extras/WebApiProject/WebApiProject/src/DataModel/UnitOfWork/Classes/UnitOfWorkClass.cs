using DataModel.Data.Context;
using DataModel.Data.Model;
using DataModel.Repository.RepositoryClass;
using DataModel.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.UnitOfWork.Classes
{
    public class UnitOfWorkClass : IUnitOfWork
    {
        private WebApiDBContext _dbContext = null;
        private GenericRepository<Users> departmentRepository;
        public UnitOfWorkClass(WebApiDBContext context)
        {
            _dbContext = context;
        }

        public GenericRepository<Users> UserRepository
        {
            get
            {

                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Users>(_dbContext);
                }
                return departmentRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveDataToDataBase()
        {
            _dbContext.SaveChanges();
        }
    }
}
