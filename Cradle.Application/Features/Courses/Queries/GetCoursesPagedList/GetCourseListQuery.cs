using Cradle.Application.Parameters;
using Cradle.Application.Wrappers;
using MediatR;

namespace Cradle.Application.Features.Courses.Queries.GetCoursesPagedList
{
    public class GetCourseListQuery : IRequest<PagedList<CourseVm>>
    {
        public RequestParameter Request { get; set; }
    }
}
