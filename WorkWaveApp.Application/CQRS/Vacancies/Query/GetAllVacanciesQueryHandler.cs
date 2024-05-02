namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class GetAllVacanciesQueryHandler : IRequestHandler<GetAllVacanciesQuery, IQueryable<GetAllVacancyDto>>
    {
        private readonly IVacancyService _vacancyService;
        public GetAllVacanciesQueryHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public async Task<IQueryable<GetAllVacancyDto>> Handle(GetAllVacanciesQuery request, CancellationToken cancellationToken)
             => await _vacancyService.GetAllVacancies();




    }
}
