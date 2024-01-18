using Cradle.Application.Contracts.Persistence;
using FluentValidation;

namespace Cradle.Application.Features.Courses.Commands
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;

        public CreateCourseCommandValidator(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            RuleFor(c => c.Name).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(c => c.Price).NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0);

            RuleFor(c => c).MustAsync(CourseUnique)
                .WithMessage("A course with same name already exists");
        }


        private async Task<bool> CourseUnique(CreateCourseCommand command, 
            CancellationToken cancellationToken)
        {
            return !(await _courseRepository.IsCourseNameAndDurationUnique(command.Name, command.Duration));
        }
    }
}
