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
