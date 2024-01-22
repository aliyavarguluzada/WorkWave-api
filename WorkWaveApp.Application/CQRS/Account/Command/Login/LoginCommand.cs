using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Models.v1.Account.Login;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Account.Command.Login
{
    public class LoginCommand : IRequest<ServiceResult<LoginResponse>>
    {
        public LoginCommand(LoginRequest request)
        {
            LoginRequest = request;
        }
        public LoginRequest LoginRequest { get; set; }
    }
}
