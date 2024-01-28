using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveAPP.Application.Core;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Models.v1.Vacancy.Response;

namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class SearchVacancyQueryHandler : IRequestHandler<SearchVacancyQuery, ServiceResult<GetVacancyByQueryResponse<Vacancy>>>
    {
        private readonly IVacancyService _vacancyService;

        public SearchVacancyQueryHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public async Task<ServiceResult<GetVacancyByQueryResponse<Vacancy>>> Handle(SearchVacancyQuery request, CancellationToken cancellationToken)
            => await _vacancyService.SearchVacancy(request.VacancyNames);



    }
}
