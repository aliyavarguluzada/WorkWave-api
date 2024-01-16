using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Domain.Entities;

namespace WorkWaveApp.Application.Interfaces
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
        public string ValidateToken(string token);
    }
}
