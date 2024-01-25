using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").WithMessage("Enter a valid email");

            RuleFor(c => c.RegisterRequest.Password)
                .NotEmpty().WithMessage("Password can not be empty")
                .Matches("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$").WithMessage("Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character.");

            RuleFor(c => c.RegisterRequest.ConfirmPassword)
                .NotEmpty().WithMessage("ConfirmPassword can not be empty")
                .Equal(c => c.RegisterRequest.Password).WithMessage("Passwords do not match");
        }
    }
}
