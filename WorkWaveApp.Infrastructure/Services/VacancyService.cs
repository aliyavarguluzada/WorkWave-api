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
using WorkWaveApp.Domain.Entities;
using FluentValidation.Validators;
using Microsoft.Extensions.Configuration;
using System.IO;
using WorkWaveApp.Infrastructure.Dtos.Vacancy;
using Microsoft.EntityFrameworkCore;
namespace WorkWaveApp.Infrastructure.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public VacancyService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ServiceResult<VacancyResponse>> AddVacancy(VacancyRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (String.IsNullOrEmpty(request.Name))
                    return ServiceResult<VacancyResponse>.Error(ErrorCodesEnum.Empty_Field_Error);

                if (String.IsNullOrEmpty(request.Description))
                    return ServiceResult<VacancyResponse>.Error(ErrorCodesEnum.Empty_Field_Error);

                if (String.IsNullOrEmpty(request.Email))
                    return ServiceResult<VacancyResponse>.Error(ErrorCodesEnum.Empty_Field_Error);


                var newVacancy = new Vacancy
                {

                    Name = request.Name,
                    Description = request.Description,
                    Email = request.Email,
                    CityId = request.CityId,
                    StatusId = request.StatusId,
                    EducationId = request.EducationId,
                    JobCategoryId = request.JobCategoryId,
                    JobTypeId = request.JobTypeId,
                    WorkFormId = request.WorkFormId,
                    StartDate = DateTime.Now,
                    ExpireDate = DateTime.Now.AddDays(19),
                    ExperienceId = request.ExperienceId,
                    CompanyId = request.CompanyId,
                };


                if (!Directory.Exists(_configuration["LogoPath:Path"]))
                {
                    DirectoryInfo di = Directory.CreateDirectory(_configuration["LogoPath:Path"]);
                }


                if (request.Logo != null && request.Logo.Length > 0)
                {
                    var fileName = Guid.NewGuid() + Path.GetExtension(request.Logo.FileName);
                    var filePath = Path.Combine(_configuration["LogoPath:Path"], fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.Logo.CopyToAsync(fileStream);
                    }

                    newVacancy.Logo = fileName;


                }




                await _context.Vacancies.AddAsync(newVacancy);
                await transaction.CommitAsync();
                await _context.SaveChangesAsync();

                var response = new VacancyResponse
                {
                    Email = request.Email,
                    Name = request.Name,
                    VacancyId = newVacancy.Id
                };

                return ServiceResult<VacancyResponse>.Ok(response);
            }
            catch (Exception)
            {
                transaction.Rollback();
                return ServiceResult<VacancyResponse>.Error(ErrorCodesEnum.Vacancy_Add_Fail);
            }
        }

        public async Task<IEnumerable<Domain.Entities.Vacancy>> GetAllVacancies()
        {
            var allVacancies = await _context
               .Vacancies
               .AsNoTracking()
               //.Select(c => new GetAllVacancyDto
               //{
               //    VacancyId = c.Id,
               //    VacancyName = c.Name,
               //    ExpireDate = c.ExpireDate,
               //    StartDate = c.StartDate
               //})
               .OrderBy(c => c.Id)
               .ToListAsync();



            return allVacancies;
        }

        public Task<ServiceResult<VacancyResponse>> GetVacancyById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<VacancyResponse>> SearchVacancy(string VacancyName)
        {
            throw new NotImplementedException();
        }
    }
}
