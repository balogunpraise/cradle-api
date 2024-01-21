using Cradle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Application.Features.Courses.Queries.GetCoursesPagedList
{
    public class GetCoursesPagedListSpec
    {
        public IQueryable<Course> Query { get; set; }
        public GetCoursesPagedListSpec(int pageNumber, int pageSize, string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                Query.Where(x => x.Name.Contains(filter));

                Query.Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).AsNoTracking();
                Query.Select(c => new CourseVm 
                {
                    Name = c.Name,
                    Id = c.Id,
                    Description = c.Description,
                });

            }
        }
    }
}
