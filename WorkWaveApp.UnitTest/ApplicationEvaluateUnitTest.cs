using FluentValidation.TestHelper;
using WorkWaveApp.Application.CQRS.Account.Command.Register;
using WorkWaveApp.Domain.Enums;
using WorkWaveApp.Models.v1.Account.Register;

namespace WorkWaveApp.UnitTest
{
    [TestFixture]
    public class Tests
    {
        private readonly RegisterCommandValidator validator = new RegisterCommandValidator();

        [Test]
        public void RegisterCommandValidator_Testing_Email()
        {
            var emailCase = new RegisterRequest
            {
                Name = "AliyavarGuluzada",
                Email = "",
                Password = "a",
                ConfirmPassword = "Scguluzadeh362!@#"
            };

            var result = validator.TestValidate(new RegisterCommand(emailCase));

            result.ShouldHaveValidationErrorFor(c => c.RegisterRequest.Email);
        }

        [Test]
        public void RegisterCommandValidator_Testing_Password()
        {
            var passwordCase = new RegisterRequest
            {
                Name = "AliyavarGuluzada",
                Email = "aliyavarguluzada@gmail.com",
                Password = "a",
                ConfirmPassword = "Scguluzadeh362!@#"
            };

            var result = validator.TestValidate(new RegisterCommand(passwordCase));

            result.ShouldHaveValidationErrorFor(c => c.RegisterRequest.Password);
        }

        [Test]
        public void RegisterCommandValidator_Testing_Name()
        {
            var nameCase = new RegisterRequest
            {
                Name = "",
                Email = "aliyavarguluzada@gmail.com",
                Password = "Scguluzadeh362!@#",
                ConfirmPassword = "Scguluzadeh362!@#"
            };

            var result = validator.TestValidate(new RegisterCommand(nameCase));

            result.ShouldHaveValidationErrorFor(c => c.RegisterRequest.Name).WithErrorMessage("Name can not be empty");
        }

    }
}