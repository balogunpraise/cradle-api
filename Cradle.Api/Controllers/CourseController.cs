using Cradle.Application.Features.Courses.Queries.GetCoursesPagedList;
using Cradle.Application.Parameters;
using Cradle.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Cradle.Api.Controllers
{
    public class CourseController(IMediator mediator) : BaseApiController(mediator)
    {
        [HttpGet("course")]
        //[Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<PagedList<CourseVm>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetCourseList([FromQuery]RequestParameter request)
        {
            var data = await _mediator.Send(new GetCourseListQuery() { Request = request });
            return Ok(new ApiResponse<PagedList<CourseVm>>(data, 200));
        }
    }
}
