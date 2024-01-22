using Cradle.Application.Features.Courses.Queries.GetCoursesPagedList;
using Cradle.Application.Features.TenantFeature.Command.RegisterTenant;
using Cradle.Application.Parameters;
using Cradle.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Cradle.Api.Controllers
{   
    public class TenantController(IMediator mediator) : BaseApiController(mediator)
    {
        [HttpPost("tenant")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetCourseList(RegisterTenantCommand request)
        {
            await _mediator.Send(request);
            return Ok(new ApiResponse(200));
        }
    }
}
