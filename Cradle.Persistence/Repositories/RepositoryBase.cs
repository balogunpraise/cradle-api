using Cradle.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cradle.Persistence.Repositories
{
    public class RepositoryBase<T>(CradleContext context) : IAsyncRepository<T> where T : class
    {
        private readonly CradleContext _context = context;
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.Set<T>().ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
