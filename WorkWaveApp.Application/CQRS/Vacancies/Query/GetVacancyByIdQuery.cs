using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Domain.Entities;

namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class GetVacancyByIdQuery : IRequest<Vacancy>
    {
        public GetVacancyByIdQuery(int id)
        {
            VacancyId = id;
        }
        public int VacancyId { get; set; }
        public string VacancyName { get; set; }
        public string VacancyDescription { get; set; }
        public int VacancyStatusId { get; set; }
        public int VacancyCompanyId { get; set; }
        public int VacancyJobTypeId { get; set; }
        public int VacancyJobCategoryId { get; set; }
        public int VacancyWorkFormId { get; set; }
        public int VacancyCityId { get; set; }
        public int VacancyExperienceId { get; set; }
        public int VacancyEducationId { get; set; }
        public string VacancyEmail { get; set; }
        public string VacancyLogo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }

    }
}
