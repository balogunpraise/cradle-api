using MediatR;

namespace Cradle.Application.Features.Courses.Queries
{
    public class GetCourseListQuery : IRequest<List<CourseVm>>
    {
    }
}
