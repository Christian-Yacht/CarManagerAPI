using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIassignment2.Interfaces
{
    public interface IProcessable<T>
    {
        IEnumerable<T> GetData();
        Task<T> GetDataById(int id);
        Task<T> DeleteData(int id);
        Task AddData(T t);
        Task UpdateData(int id, T t);
    }
}
