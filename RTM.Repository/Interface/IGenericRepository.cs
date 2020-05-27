using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T TEntity);
        Task Update(T TEntity);
        Task< IEnumerable<T>> Get();
    }
}
