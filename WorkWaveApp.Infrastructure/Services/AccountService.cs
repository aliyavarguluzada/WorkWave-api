using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Infrastructure.Data;
using WorkWaveApp.Models.v1.Account.Login;
using WorkWaveApp.Models.v1.Account.Register;
using WorkWaveAPP.Application.Core;

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

        public Task<ServiceResult<RegisterResponse>> Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
