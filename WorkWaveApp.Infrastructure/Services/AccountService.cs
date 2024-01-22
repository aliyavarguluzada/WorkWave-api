using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Infrastructure.Data;
using WorkWaveApp.Infrastructure.Dtos.User;
using WorkWaveApp.Models.v1.Account.Login;
using WorkWaveApp.Models.v1.Account.Register;
using WorkWaveAPP.Application.Core;
using WorkWaveApp.Domain.Enums;
using WorkWaveApp.Domain.Entities;

namespace WorkWaveApp.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;
        public AccountService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        public Task<ServiceResult<LoginResponse>> Login(LoginRequest request)
        {
            throw new NotImplementedException();
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

                if (request.Email == string.Empty)
                    return ServiceResult<RegisterResponse>.Error(ErrorCodesEnum.Email_Is_Not_Correct);

                if (request.Name == string.Empty)
                    return ServiceResult<RegisterResponse>.Error(ErrorCodesEnum.Username_Is_Empty);

                if (request.Password == string.Empty)
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
