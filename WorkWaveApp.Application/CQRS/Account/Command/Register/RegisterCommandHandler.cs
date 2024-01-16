using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Models.v1.Account.Register;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Account.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ServiceResult<RegisterResponse>>
    {
        private readonly IAccountService _accountService;

        public RegisterCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<ServiceResult<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
            => await _accountService.Register(request.RegisterRequest);
    }
}
