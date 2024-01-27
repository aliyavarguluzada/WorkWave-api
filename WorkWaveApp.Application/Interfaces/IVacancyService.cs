﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Models.v1.Vacancy;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.Interfaces
{
    public interface IVacancyService
    {
        Task<ServiceResult<VacancyResponse>> AddVacancy(VacancyRequest request);
        Task<ServiceResult<VacancyResponse>> GetVacancyById(int Id);
        Task<ServiceResult<VacancyResponse>> SearchVacancy(string VacancyName);
        Task<IEnumerable<Vacancy>> GetAllVacancies();
    }
}
