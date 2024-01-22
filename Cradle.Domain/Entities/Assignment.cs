using Cradle.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Domain.Entities
{
    public class Assignment : FullAuditedEntity
    {
        public string Title { get; set; }
    }
}
