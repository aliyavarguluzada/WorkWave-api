using MediatR;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Models.Dtos;

namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class GetAllVacanciesQueryHandler : IRequestHandler<GetAllVacanciesQuery, IEnumerable<GetAllVacancyDto>>
    {
        private readonly IVacancyService _vacancyService;
        public GetAllVacanciesQueryHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public async Task<IEnumerable<GetAllVacancyDto>> Handle(GetAllVacanciesQuery request, CancellationToken cancellationToken)
             => await _vacancyService.GetAllVacancies();




    }
}
