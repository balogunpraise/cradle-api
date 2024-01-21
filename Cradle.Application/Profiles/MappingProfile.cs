using AutoMapper;
using Cradle.Application.Features.Courses.Commands;
using Cradle.Application.Features.Courses.Queries.GetCoursesPagedList;
using Cradle.Domain.Entities;

namespace Cradle.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Course, CourseVm>().ReverseMap();
            CreateMap<CreateCourseCommand, Course>().ReverseMap();
        }

    }
}
