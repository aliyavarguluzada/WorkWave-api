using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Models.v1.Vacancy;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Account.Query.Vacancy
{
    public class GetAllVacanciesQuery : IRequest<IEnumerable<Domain.Entities.Vacancy>>
    {
        public string VacancyName { get; set; }
        public int VacancyId { get; set; }
        public int VacancyStatusId { get; set; }
        public string VacancyLogo { get; set; }
    }
}
