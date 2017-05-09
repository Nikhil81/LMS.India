using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         void SaveDataToDataBase();
    }
}
