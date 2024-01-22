using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Models.v1.Vacancy;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Account.Query.Vacancy
{
    public class GetVacancyQuery : IRequest<ServiceResult<VacancyResponse>>
    {
        public GetVacancyQuery(VacancyRequest request)
        {
            VacancyRequest = request;
        }

        public VacancyRequest VacancyRequest { get; set; }
        public string VacancyName { get; set; }
        public int VacancyId { get; set; }
        public int VacancyStatusId { get; set; }

    }
}
