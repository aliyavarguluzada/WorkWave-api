
namespace WorkWaveApp.Application.Interfaces
{
    public interface IAuthService
    {
        public AuthResult GenerateToken(User user);
        public string ValidateToken(string token);
        public string RefreshToken(int length);
    }
}
