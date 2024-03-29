﻿using Cradle.Domain.Entities.Common;
using Cradle.Domain.Entities.LinkingEntities;

namespace Cradle.Domain.Entities
{
    public class Course : FullAuditedEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CourseCode { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<StudentCourse> Students { get; set; }

        public Course()
        {
            Students = new List<StudentCourse>();
        }
    }
}
