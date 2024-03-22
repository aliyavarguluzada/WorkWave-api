﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Models.Dtos;

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
