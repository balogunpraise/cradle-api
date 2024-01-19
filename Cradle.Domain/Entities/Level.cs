using Cradle.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cradle.Domain.Entities
{
    public class Level : FullAuditedEntity
    {
        public string GradeName { get; set; }

        [ForeignKey("SchoolId")]
        public School SchoolFk { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Coach> Coaches { get; set; }
    }
}
