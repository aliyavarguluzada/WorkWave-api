using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Domain.Enums;
using WorkWaveApp.Infrastructure.Data;
using WorkWaveApp.Models.Dtos;
using WorkWaveApp.Models.v1.Vacancy.Request;
using WorkWaveApp.Models.v1.Vacancy.Response;
using WorkWaveAPP.Application.Core;
namespace WorkWaveApp.Infrastructure.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ICacheService _cacheService;


        public VacancyService(ApplicationDbContext context, IConfiguration configuration, ICacheService cacheService)
        {
            _context = context;
            _configuration = configuration;
            _cacheService = cacheService;
        }

        public async Task<ServiceResult<AddVacancyCommandResponse>> AddVacancy(AddVacancyCommandRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (String.IsNullOrEmpty(request.Name))
                    return ServiceResult<AddVacancyCommandResponse>.Error(ErrorCodesEnum.Empty_Field_Error);

                if (String.IsNullOrEmpty(request.Description))
                    return ServiceResult<AddVacancyCommandResponse>.Error(ErrorCodesEnum.Empty_Field_Error);

                if (String.IsNullOrEmpty(request.Email))
                    return ServiceResult<AddVacancyCommandResponse>.Error(ErrorCodesEnum.Empty_Field_Error);


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

                var addedobj = await _context.Vacancies.AddAsync(newVacancy);
                var expiryTime = DateTime.Now.AddSeconds(30);
                _cacheService.SetData<Vacancy>($"vacancy{addedobj}", addedobj.Entity, expiryTime);

                await transaction.CommitAsync();
                await _context.SaveChangesAsync();

                var response = new AddVacancyCommandResponse
                {
                    Email = request.Email,
                    Name = request.Name,
                    VacancyId = newVacancy.Id
                };

                return ServiceResult<AddVacancyCommandResponse>.Ok(response);
            }
            catch (Exception)
            {
                transaction.Rollback();
                return ServiceResult<AddVacancyCommandResponse>.Error(ErrorCodesEnum.Vacancy_Add_Fail);
            }
        }

        public async Task<IQueryable<GetAllVacancyDto>> GetAllVacancies()
        {
            var vacancies = _context
                .Vacancies
                .AsNoTracking()
                .Select(c => new GetAllVacancyDto
                {
                    VacancyId = c.Id,
                    VacancyLogo = c.Logo,
                    VacancyName = c.Name,
                    CreatedDate = (DateTime)c.CreatedDate,
                    ExpiryDate = c.ExpireDate
                })
                .AsQueryable();

            //var vacancies = await _context.Vacancies.ToListAsync();

            //var vacancies = CompiledQuery(_context).ToList();


            return vacancies;
        }

        public async Task<List<Vacancy>> GetVac()
        {
            var vacancies = await _context.Vacancies.ToListAsync();
            return vacancies;

        }

        public async Task<IEnumerable<GetAllVacancyDto>> GetAllVacanciesCached()
        {

            var cachedVacancies = _cacheService.GetData<IEnumerable<GetAllVacancyDto>>("vacancies");


            if (cachedVacancies is not null && cachedVacancies.Count() > 0)
                return cachedVacancies;


            cachedVacancies = await _context
                      .Vacancies
                      .Select(c => new GetAllVacancyDto
                      {
                          VacancyId = c.Id,
                          VacancyName = c.Name,
                          CreatedDate = (DateTime)c.CreatedDate,
                          ExpiryDate = c.ExpireDate
                      })
                      .AsNoTracking()
                      .ToListAsync();


            var expiryTime = DateTimeOffset.Now.AddSeconds(30);

            var x = _cacheService.SetData<IEnumerable<GetAllVacancyDto>>("vacancies", cachedVacancies, expiryTime);

            return cachedVacancies;
        }

        [OutputCache]
        public async Task<ServiceResult<GetVacancyByQueryResponse<Vacancy>>> GetVacancyById(int Id)
        {

            if (Id == 0)
                return ServiceResult<GetVacancyByQueryResponse<Vacancy>>.Error(ErrorCodesEnum.Empty_Field_Error);

            var vacancy = await _context
                .Vacancies
                .TagWith("GetAllVacancies")
                //.Include(c => c.Company)
                //.Include(c => c.City)
                //.Include(c => c.JobType)
                //.Include(c => c.JobCategory)
                //.Include(c => c.WorkForm)
                //.Include(c => c.Education)
                //.Include(c => c.CreatedDate)
                //.Include(c => c.UpdatedDate)
                .AsNoTracking()
                .Where(c => c.Id == Id)
                .FirstOrDefaultAsync();

            if (vacancy is null)
                return ServiceResult<GetVacancyByQueryResponse<Vacancy>>.Error(ErrorCodesEnum.Null_Error);


            var response = new GetVacancyByQueryResponse<Vacancy>
            {
                Value = vacancy
            };

            return ServiceResult<GetVacancyByQueryResponse<Vacancy>>.Ok(response);
        }

        [OutputCache]
        public async Task<ServiceResult<GetVacancyByQueryResponse<Vacancy>>> SearchVacancy(string VacancyName)
        {

            if (VacancyName == "")
                return ServiceResult<GetVacancyByQueryResponse<Vacancy>>.Error(ErrorCodesEnum.Empty_Field_Error);

            var vacancy = await _context
                .Vacancies
                .AsNoTracking()
                .Where(c => c.Name.Replace("-", "").ToLower().Contains(VacancyName.Replace("-", "").ToLower()))
                .FirstOrDefaultAsync();

            var response = new GetVacancyByQueryResponse<Vacancy>
            {
                Value = vacancy
            };

            return ServiceResult<GetVacancyByQueryResponse<Vacancy>>.Ok(response);
        }

        private static readonly Func<ApplicationDbContext, IEnumerable<GetAllVacancyDto>> CompiledQuery =
            EF.CompileQuery((ApplicationDbContext context) =>
                                    context.Vacancies.Select(c => new GetAllVacancyDto
                                    {
                                        VacancyId = c.Id,
                                        VacancyLogo = c.Logo,
                                        VacancyName = c.Name,
                                        CreatedDate = (DateTime)c.CreatedDate,
                                        ExpiryDate = c.ExpireDate
                                    }));
    }
}
