using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cradle.Api.Controllers
{
    public class StudentController(IMediator mediator) : BaseApiController(mediator)
    {
    }
}
