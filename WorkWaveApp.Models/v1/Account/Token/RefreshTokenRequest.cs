using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveApp.Models.v1.Account.Token
{
    public class RefreshTokenRequest
    {
        public required string Token { get; set; }
        public required string RefreshToken { get; set; }
    }
}
