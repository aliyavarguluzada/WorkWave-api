using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Infrastructure.Data;
using WorkWaveApp.Infrastructure.Services;
using WorkWaveApp.Models.v1.Account.Register;

namespace WorkWaveApp.UnitTest
{
    [TestFixture]
    public class Tests
    {
        
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public Tests(ApplicationDbContext context) 
        {
            _context = context;
        }

        [SetUp]
        public void Setup() 
        {
            var service = new AccountService(context: _context, authService: _authService);

        }
        [Test]
        public void AccountServiceRegister_Email_Testing()
        {
            // Arrange
            var AccountService = new AccountService(context:_context, authService:_authService); // Replace with the actual class name
            var validRequest = new RegisterRequest
            {
                Email = "test@example.com",
                Name = "TestUser",
                Password = "Password123",
                ConfirmPassword = "Password123"
            };

            // Act
            var result = AccountService.Register(validRequest);

            // Assert
            Assert.That(result.IsCompletedSuccessfully, Is.True);
            Assert.That(result.Result, Is.Not.Null);
            Assert.Fail(result.Result.Response.Name);
        }
    }
}