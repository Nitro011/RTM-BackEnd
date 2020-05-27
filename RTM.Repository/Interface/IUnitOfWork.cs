using RTM.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Repository.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        RTMDbContext context { get; }
        void Commit();
    }
}
