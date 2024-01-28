using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Models.v1.Vacancy.Response;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class GetVacancyByIdQueryHandler : IRequestHandler<GetVacancyByIdQuery, ServiceResult<GetVacancyByQueryResponse<Vacancy>>>
    {
        private readonly IVacancyService _vacancyService;

        public GetVacancyByIdQueryHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public async Task<ServiceResult<GetVacancyByQueryResponse<Vacancy>>> Handle(GetVacancyByIdQuery request, CancellationToken cancellationToken)
              => await _vacancyService.GetVacancyById(request.VacancyId);



    }
}
