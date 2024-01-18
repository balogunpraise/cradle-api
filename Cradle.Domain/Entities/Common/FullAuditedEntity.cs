using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Domain.Entities.Common
{
    public class FullAuditedEntity : BaseEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string UpdateBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
