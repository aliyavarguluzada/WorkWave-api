using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Domain.Entities;
using WorkWaveAPP.Application.Core;
using WorkWaveApp.Models.v1.Vacancy.Response;

namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class SearchVacancyQuery : IRequest<ServiceResult<GetVacancyByQueryResponse<Vacancy>>>
    {
        public SearchVacancyQuery(string VacancyName)
        {
            VacancyNames = VacancyName;
        }
        public string VacancyNames { get; set; }
    }
}
