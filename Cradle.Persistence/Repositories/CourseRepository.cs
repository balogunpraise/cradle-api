using Azure.Core;
using Cradle.Application.Contracts.Persistence;
using Cradle.Application.Features.Courses.Queries.GetCoursesPagedList;
using Cradle.Application.Parameters;
using Cradle.Application.Wrappers;
using Cradle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Persistence.Repositories
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(CradleContext context) : base(context)
        {
        }

        public Task<bool> IsCourseNameAndDurationUnique(string name, string duration)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<CourseVm>> ListCourses(RequestParameter request)
        {
            IQueryable<Course> courseQuery = _context.Courses;
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                courseQuery.Where(c => c.Name.Contains(request.SearchTerm) || c.CourseCode.Contains(request.SearchTerm));
            }

            

            if(request.SortOrder?.ToLower() == "desc")
            {
                courseQuery = courseQuery.OrderByDescending(GetSortProperty(request.SortColumn));
            }
            else
            {
                courseQuery = courseQuery.OrderBy(GetSortProperty(request.SortColumn));
            }
            var coursesResponseQuery = courseQuery.Select(c => new CourseVm
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                TenantId = c.TenantId
            });
            var courses = await PagedList<CourseVm>.ToPagedList(coursesResponseQuery, request.PageNumber, request.PageSize);
            return courses;
        }

        private static Expression<Func<Course, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn?.ToLower() switch
            {
                "name" => course => course.Name,
                "code" => course => course.CourseCode,
                _ => course => course.Id
            };
        }
    }
}
