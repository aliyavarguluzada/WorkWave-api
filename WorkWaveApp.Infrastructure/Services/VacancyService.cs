using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Infrastructure.Data;
using WorkWaveApp.Models.v1.Vacancy;
using WorkWaveAPP.Application.Core;
using WorkWaveApp.Domain.Enums;
namespace WorkWaveApp.Infrastructure.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly ApplicationDbContext _context;

        public VacancyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<VacancyResponse>> AddVacancy(VacancyRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (String.IsNullOrEmpty(request.Name))
                    return ServiceResult<VacancyResponse>.Error(ErrorCodesEnum.Empty_Field_Error);

                if(String.IsNullOrEmpty(request.Description))
                    return ServiceResult<VacancyResponse>.Error(ErrorCodesEnum.Empty_Field_Error); 
                
                if(String.IsNullOrEmpty(request.Email))
                    return ServiceResult<VacancyResponse>.Error(ErrorCodesEnum.Empty_Field_Error);

                var response = new VacancyResponse
                {
                    
                };

                return ServiceResult<VacancyResponse>.Ok(response);
            }
            catch (Exception)
            {
                transaction.Rollback();
                return ServiceResult<VacancyResponse>.Error(ErrorCodesEnum.Vacancy_Add_Fail);
            }
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
