using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Domain.Entities.LinkingEntities
{
    public class UserAssignment
    {
        public string UserId { get; set; }
        public string AssignmentId { get; set; }
        public ApplicationUser User { get; set; }
        public Assignment Assignment { get; set; }
    }
}
