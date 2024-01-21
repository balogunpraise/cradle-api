using Cradle.Application.Contracts.Persistence;
using Cradle.Application.Wrappers;
using MediatR;

namespace Cradle.Application.Features.Courses.Queries.GetCoursesPagedList
{
    public class GetCourseListQueryHandler(ICourseRepository courseRepository) 
        : IRequestHandler<GetCourseListQuery, PagedList<CourseVm>>
    {
        private readonly ICourseRepository _courseRepository = courseRepository;

        public async Task<PagedList<CourseVm>> Handle(GetCourseListQuery request,
            CancellationToken cancellationToken)
        {
            return await _courseRepository.ListCourses(request.Request);
        }
    }
}
