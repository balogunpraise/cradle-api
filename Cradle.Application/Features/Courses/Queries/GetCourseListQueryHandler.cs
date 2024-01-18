using AutoMapper;
using Cradle.Application.Contracts.Persistence;
using Cradle.Domain.Entities;
using MediatR;

namespace Cradle.Application.Features.Courses.Queries
{
    public class GetCourseListQueryHandler(IAsyncRepository<Course> courseRepository,
        IMapper mapper) : IRequestHandler<GetCourseListQuery, List<CourseVm>>
    {
        private readonly IAsyncRepository<Course> _courseRepository = courseRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<CourseVm>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.ListAllAsync();
            return _mapper.Map<List<CourseVm>>(courses);
        }
    }
}
