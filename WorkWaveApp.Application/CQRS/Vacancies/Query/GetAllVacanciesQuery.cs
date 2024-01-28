using MediatR;

namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class GetAllVacanciesQuery : IRequest<IEnumerable<Domain.Entities.Vacancy>>
    {
        public string VacancyName { get; set; }
        public int VacancyId { get; set; }
        public int VacancyStatusId { get; set; }
        public string VacancyLogo { get; set; }
    }
}
