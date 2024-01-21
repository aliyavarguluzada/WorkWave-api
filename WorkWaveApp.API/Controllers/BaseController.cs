using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkWaveApp.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IMediator Meadiator { get => _mediator ?? HttpContext.RequestServices.GetRequiredService<IMediator>(); }
    }
}
