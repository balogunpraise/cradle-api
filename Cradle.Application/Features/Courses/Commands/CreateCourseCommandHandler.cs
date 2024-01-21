using AutoMapper;
using Cradle.Application.Contracts.Persistence;
using Cradle.Domain.Entities;
using MediatR;
 
namespace Cradle.Application.Features.Courses.Commands
{
    public class CreateCourseCommandHandler(ICourseRepository courseRepository,
        IMapper mapper)
        : IRequestHandler<CreateCourseCommand, string>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICourseRepository _courseRepository = courseRepository;

        public async Task<string> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var @course = _mapper.Map<Course>(request);
            var validator = new CreateCourseCommandValidator(_courseRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count != 0)
                throw new Exceptions.ValidationException(validationResult);
            @course = await _courseRepository.AddAsync(@course);
            return course.Id;
        }
    }
}
