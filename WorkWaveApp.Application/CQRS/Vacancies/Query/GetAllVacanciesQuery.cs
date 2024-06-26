﻿
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
