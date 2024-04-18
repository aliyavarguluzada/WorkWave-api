using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WorkWaveApp.Application.CQRS.Account.Command.Login;
using WorkWaveApp.Application.CQRS.Account.Command.Register;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Domain.Entities;
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
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ServiceResult<RegisterResponse>> Register([FromBody] RegisterRequest request)
            => await Mediator.Send(new RegisterCommand(request));

        [HttpPost("login")]
        public async Task<ServiceResult<LoginResponse>> Login([FromBody] LoginRequest request)
            => await Mediator.Send(new LoginCommand(request));

        [HttpGet("GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            var users = await accountService.GetAllUsers();
            return users;
        }
    }
}
