using MediatR;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Models.Dtos;
using WorkWaveApp.Models.v1.Vacancy.Response;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class GetAllVacanciesQuery : IRequest<IQueryable<GetAllVacancyDto>>
    {
        public int VacancyId { get; set; }
        public int VacancyStatusId { get; set; }
        public string VacancyName { get; set; }
        public string VacancyLogo { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
