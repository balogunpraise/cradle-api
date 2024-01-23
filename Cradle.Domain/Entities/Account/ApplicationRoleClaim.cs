using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Domain.Entities.Account
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public string TenantId { get; set; }
        public string SchoolId { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
    }
}
