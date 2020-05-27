using Microsoft.EntityFrameworkCore;
using RTM.Persistence;
using RTM.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IUnitOfWork _context;

        public GenericRepository(IUnitOfWork context)
        {
            this._context = context;
        }

        public async Task Add(T TEntity)
        {
            _context.context.Set<T>().Add(TEntity);
            await _context.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _context.context.Set<T>().ToListAsync();
        }

        public async Task Update(T TEntity)
        {
            _context.context.Entry(TEntity).State = EntityState.Modified;

            await Task.CompletedTask;
        }

        
    }
}
