using FluentValidation;

namespace WorkWaveApp.Application.CQRS.Account.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.RegisterRequest.Name)
                .NotEmpty().WithMessage("Name can not be empty")
                .MinimumLength(2).WithMessage("Minimum Name length is 2")
                .MaximumLength(20).WithMessage("Max Name length is 20");

            RuleFor(c => c.RegisterRequest.Email)
                .NotEmpty().WithMessage("Email can not be empty")
                //.Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$\r\n")
                .WithMessage("Enter a valid email");

            RuleFor(c => c.RegisterRequest.Password)
                .NotEmpty().WithMessage("Password can not be empty")
                //.Matches("^[A-Za-z][A-Za-z][A-Za-z][A-Za-z][A-Za-z][A-Za-z]z[A-Za-z]d[A-Za-z][A-Za-z]\\d\\d2!@#$")
                .WithMessage("Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character.");

            RuleFor(c => c.RegisterRequest.ConfirmPassword)
                .NotEmpty().WithMessage("ConfirmPassword can not be empty")
                .Equal(c => c.RegisterRequest.Password).WithMessage("Passwords do not match");
        }
    }
}