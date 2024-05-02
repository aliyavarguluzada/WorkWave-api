

namespace WorkWaveApp.Application.CQRS.Account.Command.Login
{
    public class LoginCommand : IRequest<ServiceResult<LoginResponse>>
    {
        public LoginCommand(LoginRequest request)
        {
            LoginRequest = request;
        }
        public LoginRequest LoginRequest { get; set; }
    }
}
