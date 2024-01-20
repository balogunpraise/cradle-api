using AutoMapper;
using Cradle.Application.Contracts.Persistence;
using Cradle.Domain.Entities;
using MediatR;

namespace Cradle.Application.Features.Courses.Queries
{
    public class GetCourseListQueryHandler(ICourseRepository courseRepository,
        IMapper mapper) : IRequestHandler<GetCourseListQuery, List<CourseVm>>
    {
        private readonly ICourseRepository _courseRepository = courseRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<CourseVm>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.ListAllAsync(request.Request);
            return _mapper.Map<List<CourseVm>>(courses);
        }
    }
}
