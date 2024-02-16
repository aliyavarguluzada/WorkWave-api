using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Core;
using WorkWaveApp.Domain.Entities;

namespace WorkWaveApp.Application.Interfaces
{
    public interface IAuthService
    {
        public AuthResult GenerateToken(User user);
        public string ValidateToken(string token);
        public string RefreshToken(int length);
    }
}
