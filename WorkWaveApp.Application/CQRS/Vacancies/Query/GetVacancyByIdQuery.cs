using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Models.v1.Vacancy.Response;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class GetVacancyByIdQuery : IRequest<ServiceResult<GetVacancyByQueryResponse<Vacancy>>>
    {
        public GetVacancyByIdQuery(int id)
        {
            VacancyId = id;
        }
        public int VacancyId { get; set; }


    }
}
