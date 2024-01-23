using Cradle.Application.Contracts.Persistence;
using Cradle.Domain.Entities;

namespace Cradle.Persistence.Repositories
{
    public class SchoolRepository(CradleContext context) : RepositoryBase<School>(context), ISchoolRepository
    {
        public async Task<int> CreateSchool(School school)
        {
            await _context.Schools.AddAsync(school);
            return await _context.SaveChangesAsync();
        }
    }
}
