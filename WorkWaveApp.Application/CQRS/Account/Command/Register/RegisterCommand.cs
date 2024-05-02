
namespace WorkWaveApp.Application.CQRS.Account.Command.Register
{
    public class RegisterCommand : IRequest<ServiceResult<RegisterResponse>>
    {
        public RegisterCommand(RegisterRequest request)
        {
            RegisterRequest = request;
        }
        public RegisterRequest RegisterRequest { get; set; }
    }
}
