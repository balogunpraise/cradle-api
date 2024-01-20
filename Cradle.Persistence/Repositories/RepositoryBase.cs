using Cradle.Application.Contracts.Persistence;
using Cradle.Application.Parameters;
using Cradle.Application.Wrappers;
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

        public async Task<PagedList<T>> ListAllAsync(RequestParameter req)
        {
            var count = await _context.Set<T>().CountAsync();
            var result = await _context.Set<T>()
                .Skip((req.PageNumber * req.PageSize) - req.PageSize)
                .Take(req.PageSize)
                .ToListAsync();
            return PagedList<T>.ToPagedList(result, req.PageNumber, req.PageSize, count);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
