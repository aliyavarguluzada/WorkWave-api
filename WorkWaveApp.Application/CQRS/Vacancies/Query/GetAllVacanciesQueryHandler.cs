﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Models.v1.Vacancy;
using WorkWaveAPP.Application.Core;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Models.v1.Vacancy.Response;

namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class GetAllVacanciesQueryHandler : IRequestHandler<GetAllVacanciesQuery, ServiceResult<GetAllVacanciesQueryResponse<Vacancy>>>
    {
        private readonly IVacancyService _vacancyService;
        public GetAllVacanciesQueryHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public async Task<ServiceResult<GetAllVacanciesQueryResponse<Vacancy>>> Handle(GetAllVacanciesQuery request, CancellationToken cancellationToken)
        
             =>  await _vacancyService.GetAllVacancies();

        


    }
}
