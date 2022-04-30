using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WantedDev.Core.DataAccess.Abstraction
{
    public interface ICrudRepository<T>
    {
        void Add(T value);
        void Delete(int id);
        void Update(T value);
        List<T> GetAll();
        T Get(int id);
    }
}
