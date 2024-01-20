using Cradle.Application.Parameters;
using MediatR;

namespace Cradle.Application.Features.Courses.Queries
{
    public class GetCourseListQuery : IRequest<List<CourseVm>>
    {
        public RequestParameter Request { get; set; }
    }
}
