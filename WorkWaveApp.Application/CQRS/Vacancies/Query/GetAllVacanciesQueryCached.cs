namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class GetAllVacanciesQueryCached : IRequest<IEnumerable<GetAllVacancyDto>>
    {
        public int VacancyId { get; init; }
        public int VacancyStatusId { get; init; }

        public string VacancyName { get; init; }
        public string VacancyLogo { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime ExpiryDate { get; init; }
    }
}
