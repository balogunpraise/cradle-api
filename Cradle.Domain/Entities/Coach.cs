using Cradle.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cradle.Domain.Entities
{
    public class Coach : FullAuditedEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string Salary { get; set; }
        public Guid GradeId { get; set; }

        [ForeignKey("GradeId")]
        public Level GradeFk { get; set; }
        public Guid CourseId { get; set; }
        public bool IsClassTeacher { get; set; }

        [ForeignKey("CourseId")]
        public Course CourseFk { get; set; }

        [ForeignKey("SchoolId")]
        public School SchoolFk { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<InternalMessage> InternalMessages { get; set; }
    }
}
