using Cradle.Application.Contracts.Persistence;
using Cradle.Application.Parameters;
using Cradle.Application.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace Cradle.Persistence.Repositories
{
    public class RepositoryBase<T>(CradleContext context) : IAsyncRepository<T> where T : class
    {
        protected readonly CradleContext _context = context;
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
