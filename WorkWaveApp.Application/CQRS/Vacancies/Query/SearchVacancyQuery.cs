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
