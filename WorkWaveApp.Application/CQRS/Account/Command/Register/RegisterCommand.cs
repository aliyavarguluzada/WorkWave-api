using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Models.v1.Account.Register;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Account.Command.Register
{
    public class RegisterCommand : IRequest<ServiceResult<RegisterResponse>>
    {
        public RegisterCommand(RegisterRequest request)
        {
            RegisterRequest = request;
        }
        public RegisterRequest RegisterRequest { get; set; }
    }
}
