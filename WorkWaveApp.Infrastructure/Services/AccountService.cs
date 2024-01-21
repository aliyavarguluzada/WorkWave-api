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

namespace WorkWaveApp.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        public AccountService(ApplicationDbContext context)
        {
            _context = context;
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

                if (user is true)
                    return ServiceResult<RegisterResponse>.Error(ErrorCodesEnum.User_AlreadyExists);





                var response = new RegisterResponse
                {
                    Email = request.Email,
                    Name = request.Name,
                };

                return ServiceResult<RegisterResponse>.Ok(response);

            }
            catch (Exception)
            {
                return ServiceResult<RegisterResponse>.Error(ErrorCodesEnum.User_AlreadyExists);
            }
        }
    }
}
