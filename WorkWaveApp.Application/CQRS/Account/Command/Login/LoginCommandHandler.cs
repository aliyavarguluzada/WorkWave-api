using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Models.v1.Account.Login;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Account.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ServiceResult<LoginResponse>>
    {
        private readonly IAccountService _accountService;
        public LoginCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public Task<ServiceResult<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
             => _accountService.Login(request.LoginRequest);
    }
}
