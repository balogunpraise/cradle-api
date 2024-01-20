using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Domain.Entities.LinkingEntities
{
    public class StudentAssignment
    {
        public string UserId { get; set; }
        public string AssignmentId { get; set; }
        public Student Student { get; set; }
        public Assignment Assignment { get; set; }
    }
}
