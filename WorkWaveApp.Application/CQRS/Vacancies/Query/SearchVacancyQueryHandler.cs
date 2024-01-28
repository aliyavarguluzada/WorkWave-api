using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;

namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class SearchVacancyQueryHandler : IRequestHandler<SearchVacancyQuery, Domain.Entities.Vacancy>
    {
        private readonly IVacancyService _vacancyService;

        public SearchVacancyQueryHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public async Task<Domain.Entities.Vacancy> Handle(SearchVacancyQuery request, CancellationToken cancellationToken)
        {
            var vacancy = await _vacancyService.SearchVacancy(request.VacancyNames);

            return vacancy;
        }
    }
}
