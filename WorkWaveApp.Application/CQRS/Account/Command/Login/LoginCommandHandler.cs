using FluentValidation;
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
        private readonly IValidator<LoginCommand> _validator;
        public LoginCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<ServiceResult<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
             => await _accountService.Login(request.LoginRequest);
    }
}
