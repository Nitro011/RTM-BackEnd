using RTM.Persistence;
using RTM.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Repository
{


    public class UnitOfWork : IUnitOfWork
    {
        public RTMDbContext context { get; }

        public UnitOfWork(RTMDbContext context)
        {
            this.context = context;
        }
        public void Commit()
        {
         var e=  context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
