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
