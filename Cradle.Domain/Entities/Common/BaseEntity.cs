using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Domain.Entities.Common
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public string SchoolId { get; set; }
        public string TenantId { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
