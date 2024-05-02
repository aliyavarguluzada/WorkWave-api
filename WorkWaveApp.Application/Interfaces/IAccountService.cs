namespace WorkWaveApp.Application.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResult<RegisterResponse>> Register(RegisterRequest request);
        Task<ServiceResult<LoginResponse>> Login(LoginRequest request);
        Task<List<User>> GetAllUsers();
    }
}
