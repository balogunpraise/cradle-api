using MediatR;

namespace Cradle.Application.Features.Courses.Commands
{
    public class CreateCourseCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public decimal Price { get; set; }
        public string Difficulty { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return $"Course name: {Name}; Price: {Price}; Duration: {Duration}";
        }
    }
}
