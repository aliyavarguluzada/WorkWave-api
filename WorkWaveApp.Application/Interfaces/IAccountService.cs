using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Models.v1.Account.Login;
using WorkWaveApp.Models.v1.Account.Register;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResult<RegisterResponse>> Register(RegisterRequest request);
        Task<ServiceResult<LoginResponse>> Login(LoginRequest request);
        Task<List<User>> GetAllUsers();
    }
}
