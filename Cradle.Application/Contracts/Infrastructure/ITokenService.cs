using Cradle.Domain.Entities.Account;
using Cradle.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Application.Contracts.Infrastructure
{
    public interface ITokenService
    {
        Task<string> GenerateToken(ApplicationUser user, Tenant tenant = null);
    }
}
