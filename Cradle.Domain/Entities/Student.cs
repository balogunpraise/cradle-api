using Cradle.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Domain.Entities
{
    [Table("Students")]
    public class Student : FullAuditedEntity
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string MiddleName { get; set; }
        public Guid GradeId { get; set; }

        [ForeignKey("GradeId")]
        public Level GradeFk { get; set; }

        [ForeignKey("SchoolId")]
        public School SchoolFk { get; set; }

    }
}
