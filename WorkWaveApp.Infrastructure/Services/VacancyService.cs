using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Models.v1.Vacancy;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Infrastructure.Services
{
    public class VacancyService : IVacancyService
    {
        public Task<ServiceResult<VacancyResponse>> AddVacancy(VacancyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<VacancyResponse>> GetAllVacancies()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<VacancyResponse>> GetVacancy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<VacancyResponse>> SearchVacancy(string VacancyName)
        {
            throw new NotImplementedException();
        }
    }
}
