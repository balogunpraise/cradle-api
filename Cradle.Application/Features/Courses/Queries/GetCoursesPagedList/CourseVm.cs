using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Application.Features.Courses.Queries.GetCoursesPagedList
{
    public class CourseVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CourseCode { get; set; }
        public string TenantId { get; set; }
    }
}
