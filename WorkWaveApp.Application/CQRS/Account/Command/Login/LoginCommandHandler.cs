using FluentValidation;
using MediatR;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Models.v1.Account.Login;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Account.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ServiceResult<LoginResponse>>
    {
        private readonly IAccountService _accountService;
        private readonly IValidator<LoginCommand> _validator;
        public LoginCommandHandler(IAccountService accountService
            , IValidator<LoginCommand> validator
            )
        {
            _accountService = accountService;
            _validator = validator;
        }
        public async Task<ServiceResult<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            return await _accountService.Login(request.LoginRequest);
        }
    }
}
