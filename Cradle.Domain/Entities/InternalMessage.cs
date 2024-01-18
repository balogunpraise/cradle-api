using Cradle.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Domain.Entities
{
    public class InternalMessage : FullAuditedEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReciepientId { get; set; }
    }
}
