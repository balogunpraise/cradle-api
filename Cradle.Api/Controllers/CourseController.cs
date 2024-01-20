using Cradle.Application.Features.Courses.Queries;
using Cradle.Application.Parameters;
using Cradle.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Cradle.Api.Controllers
{
    public class CourseController(IMediator mediator) : BaseApiController(mediator)
    {
        [HttpPost("course")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<PagedList<CourseVm>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetCourseList(RequestParameter request)
        {
            return Ok(await _mediator.Send(new GetCourseListQuery(request)));
        }
    }
}
