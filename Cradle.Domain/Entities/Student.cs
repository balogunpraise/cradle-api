using Cradle.Domain.Entities.Common;
using Cradle.Domain.Entities.LinkingEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cradle.Domain.Entities
{
    [Table("Students")]
    public class Student : FullAuditedEntity
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string MiddleName { get; set; }
        public string GradeId { get; set; }

        [ForeignKey("GradeId")]
        public Level GradeFk { get; set; }

        [ForeignKey("SchoolId")]
        public School SchoolFk { get; set; }

        public virtual ICollection<StudentCourse> Courses { get; set; }
        public virtual ICollection<StudentAssignment> Assignments { get; set; }

        public Student()
        {
            Assignments = new List<StudentAssignment>();
            Courses = new List<StudentCourse>();
        }

    }
}
