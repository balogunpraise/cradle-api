using Cradle.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Application.Contracts.Persistence
{
    public interface ISchoolRepository : IAsyncRepository<School>
    {
        Task<int> CreateSchool(School school);
    }
}
