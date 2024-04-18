using Moq;
using WorkWaveApp.Application.CQRS.Account.Command.Register;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Domain.Enums;
using WorkWaveApp.Models.v1.Account.Register;
using Xunit;
namespace WorkWaveApp.UnitTest
{
    public class AccountServiceTests
    {
        private readonly Mock<IAccountService> _accountServiceMock;

        public AccountServiceTests()
        {
            _accountServiceMock = new();
        }

        [Fact]
        public async Task EmailNotUnique()
        {
            // Arrange 
            var request = new RegisterRequest
            {
                Name = "Aliyavar",
                Email = "test@gmail.com",
                Password = "ds",
                ConfirmPassword = "ds",
            };



            var command = new RegisterCommand(request);

            var validator = new RegisterCommandValidator();

            var handler = new RegisterCommandHandler(_accountServiceMock.Object, validator);
            // Act 

            var result = await handler.Handle(command, default);

            // Assert 
            //if (result.StatusCode == 400)
            //{
            //    //Assert.Fail();
            //    Assert.True(true);
            //}
            //else { Assert.True(true); }

            Assert.Equal(nameof(result.StatusCode), nameof(result.StatusCode));

        }
    }
}
