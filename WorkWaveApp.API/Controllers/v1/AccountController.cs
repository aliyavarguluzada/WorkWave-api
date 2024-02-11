using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkWaveApp.Application.CQRS.Account.Command.Login;
using WorkWaveApp.Application.CQRS.Account.Command.Register;
using WorkWaveApp.Models.v1.Account.Login;
using WorkWaveApp.Models.v1.Account.Register;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.API.Controllers.v1
{
    [Route("api/v{version:apiversion}/account")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountController : BaseController
    {


        [HttpPost("register")]
        public async Task<ServiceResult<RegisterResponse>> Register([FromBody] RegisterRequest request)
            => await Mediator.Send(new RegisterCommand(request));

        [HttpPost("login")]
        public async Task<ServiceResult<LoginResponse>> Login([FromBody] LoginRequest request)
            => await Mediator.Send(new LoginCommand(request));
    }
}
