using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkWaveApp.Application.CQRS.Account.Command.Register;
using WorkWaveApp.Models.v1.Account.Register;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.API.Controllers.v1
{
    [Route("api/v{version:apiversion}/account")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountController : BaseController
    {

        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ServiceResult<RegisterResponse>> Register([FromBody] RegisterRequest request)
            => await _mediator.Send(new RegisterCommand(request));
    }
}
