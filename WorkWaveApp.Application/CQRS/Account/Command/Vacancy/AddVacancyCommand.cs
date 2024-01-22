using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Models.v1.Vacancy;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Account.Command.Vacancy
{
    public class AddVacancyCommand : IRequest<ServiceResult<VacancyResponse>>
    {
        public AddVacancyCommand(VacancyRequest request)
        {
            VacancyRequest = request;
        }
        public VacancyRequest VacancyRequest;
    }
}
