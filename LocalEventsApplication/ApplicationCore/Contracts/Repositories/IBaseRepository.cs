using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int Id);
        ICollection<T> GetAll();
        int Create(T Entity);
        int Update(T Entity);
        int DeleteById(int Id);
    }
}
