using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Domain.Enums;
using WorkWaveApp.Infrastructure.Data;
using WorkWaveApp.Models.v1.Account.Login;
using WorkWaveApp.Models.v1.Account.Register;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public AccountService(ApplicationDbContext context,
                                 IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        public async Task<ServiceResult<LoginResponse>> Login(LoginRequest request)
        {
            try
            {

                var user = await _context
                    .Users
                    .Where(c => c.Email == request.Email)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();


                if (user is null)
                    return ServiceResult<LoginResponse>.Error(ErrorCodesEnum.User_Not_Found);

                var passCheck = user.VerifyPassword(request.Password);

                if (passCheck is false)
                    return ServiceResult<LoginResponse>.Error(ErrorCodesEnum.Password_Is_Not_Correct);

                var token = _authService.GenerateToken(user);

                var response = new LoginResponse
                {
                    UserName = user.Name,
                    Token = token
                };

                Log.Information($"New Account Login: {response}");

                return ServiceResult<LoginResponse>.Ok(response);

            }
            catch (Exception)
            {
                return ServiceResult<LoginResponse>.Error(ErrorCodesEnum.Some_Error);
            }



        }

        public async Task<ServiceResult<RegisterResponse>> Register(RegisterRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var user = await _context
                    .Users
                    .Where(c => c.Email == request.Email)
                    .AsNoTracking()
                    .AnyAsync();

                if (String.IsNullOrEmpty(request.Email))
                    return ServiceResult<RegisterResponse>.Error(ErrorCodesEnum.Email_Is_Not_Correct);

                if (String.IsNullOrEmpty(request.Name))
                    return ServiceResult<RegisterResponse>.Error(ErrorCodesEnum.Username_Is_Empty);

                if (String.IsNullOrEmpty(request.Password))
                    return ServiceResult<RegisterResponse>.Error(ErrorCodesEnum.Password_Is_Not_Correct);

                if (request.ConfirmPassword != request.Password)
                    return ServiceResult<RegisterResponse>.Error(ErrorCodesEnum.ConfirmPassword_Does_Not_Match);



                if (user is true)
                    return ServiceResult<RegisterResponse>.Error(ErrorCodesEnum.User_Already_Exists);


                var newUser = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    UserRoleId = (int)UserRoleEnum.Company,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now

                };
                newUser.AddPassword(request.Password);

                await _context.Users.AddAsync(newUser);

                await transaction.CommitAsync();

                await _context.SaveChangesAsync();


                var response = new RegisterResponse
                {
                    Email = request.Email,
                    Name = request.Name,
                    UserId = newUser.Id
                };
                Log.Information($"New Account Registered: {response}");

                return ServiceResult<RegisterResponse>.Ok(response);

            }
            catch (Exception)
            {
                transaction.Rollback();
                return ServiceResult<RegisterResponse>.Error(ErrorCodesEnum.User_Already_Exists);
            }
        }
    }
}
