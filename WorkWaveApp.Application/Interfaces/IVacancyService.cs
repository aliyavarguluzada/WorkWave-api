using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Models.v1.Vacancy.Request;
using WorkWaveApp.Models.v1.Vacancy.Response;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.Interfaces
{
    public interface IVacancyService
    {
        Task<ServiceResult<AddVacancyCommandResponse>> AddVacancy(AddVacancyCommandRequest request);
        Task<Vacancy> GetVacancyById(int Id);
        Task<Vacancy> SearchVacancy(string VacancyName);
        Task<ServiceResult<GetAllVacanciesQueryResponse<Vacancy>>> GetAllVacancies();
    }
}
