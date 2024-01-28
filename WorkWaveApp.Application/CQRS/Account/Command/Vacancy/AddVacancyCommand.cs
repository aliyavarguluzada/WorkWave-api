using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Models.v1.Vacancy.Request;
using WorkWaveApp.Models.v1.Vacancy.Response;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Account.Command.Vacancy
{
    public class AddVacancyCommand : IRequest<ServiceResult<AddVacancyCommandResponse>>
    {
        public AddVacancyCommand(AddVacancyCommandRequest request)
        {
            VacancyRequest = request;
        }
        public AddVacancyCommandRequest VacancyRequest;
    }
}
