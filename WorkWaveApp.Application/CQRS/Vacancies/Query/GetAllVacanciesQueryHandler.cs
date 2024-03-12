using MediatR;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Domain.Entities;

namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class GetAllVacanciesQueryHandler : IRequestHandler<GetAllVacanciesQuery, IEnumerable<Vacancy>>
    {
        private readonly IVacancyService _vacancyService;
        public GetAllVacanciesQueryHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public async Task<IEnumerable<Vacancy>> Handle(GetAllVacanciesQuery request, CancellationToken cancellationToken)
             => await _vacancyService.GetAllVacancies();




    }
}
