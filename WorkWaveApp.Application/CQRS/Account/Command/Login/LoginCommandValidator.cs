

namespace WorkWaveApp.Application.CQRS.Account.Command.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(c => c.LoginRequest.Email)
                .NotEmpty().WithMessage("Email can not be empty")
                //.Matches("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$")
                .WithMessage("Enter a valid email");

            RuleFor(c => c.LoginRequest.Password)
                .NotEmpty().WithMessage("Password can not be empty")
                //.Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character.");

        }
    }
}
