using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkWaveApp.Application.CQRS.Account.Command.Vacancy;
using WorkWaveApp.Application.CQRS.Vacancies.Query;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Infrastructure.Services;
using WorkWaveApp.Models.Dtos;
using WorkWaveApp.Models.v1.Vacancy.Request;
using WorkWaveApp.Models.v1.Vacancy.Response;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.API.Controllers.v1
{
    [Route("api/v{version:apiversion}/vacancy")]
    [ApiController]
    [ApiVersion("1.0")]
    public class VacancyController : BaseController
    {


        private readonly IVacancyService _vacancyService;
        public VacancyController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        [HttpPost("addVacancy"), Authorize(Roles = "company")]
        public async Task<ServiceResult<AddVacancyCommandResponse>> AddVacancy([FromForm] AddVacancyCommandRequest request)
            => await Mediator.Send(new AddVacancyCommand(request));

        [HttpGet("getAllVacanciesCached")]
        public async Task<IEnumerable<GetAllVacancyDto>> GetAllVacanciesCached()
            => await Mediator.Send(new GetAllVacanciesQueryCached());

        [HttpGet("getAllVacancies")]
        public async Task<IQueryable<GetAllVacancyDto>> GetAllVacancies()
            => await Mediator.Send(new GetAllVacanciesQuery());

        [HttpGet("getVac")]
        public async Task<List<Vacancy>> GetVac()
        {
            var vacancies = await _vacancyService.GetVac();

            return vacancies;
        }

        [HttpPost("getVacancyById")]
        public async Task<ServiceResult<GetVacancyByQueryResponse<Vacancy>>> GetVacancyById([FromBody] int id)
            => await Mediator.Send(new GetVacancyByIdQuery(id));

        [HttpPost("searchVacancy")]
        public async Task<ServiceResult<GetVacancyByQueryResponse<Vacancy>>> SearchVacancy([FromBody] string vacancyName)
            => await Mediator.Send(new SearchVacancyQuery(vacancyName));


    }
}
