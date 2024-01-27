using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Domain.Entities;

namespace WorkWaveApp.Application.CQRS.Account.Query.Vacancy
{
    public class SearchVacancyQuery : IRequest<Domain.Entities.Vacancy>
    {
        public SearchVacancyQuery(string VacancyName) 
        {
            VacancyNames = VacancyName;
        }
        public string VacancyNames { get; set; }
    }
}
