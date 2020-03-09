using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T model);
        void Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll(); 
        void Update(T model);
    }
}
