using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly GlobalTicketDbContext _dbcontext;

        public BaseRepository(GlobalTicketDbContext context)
        {
            _dbcontext = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbcontext.Set<T>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
           var result = await  _dbcontext.Set<T>().FindAsync(id);
            if (result is null)
            {
                throw new NullReferenceException();
            }
            return result;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }


    }
}
