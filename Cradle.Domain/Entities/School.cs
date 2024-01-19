using Cradle.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Domain.Entities
{
    public class School : FullAuditedEntity
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Level> Grades { get; set; }
    }
}
