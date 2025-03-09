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

        [HttpPost("vacancies"), Authorize(Roles = "company")]
        public async Task<ServiceResult<AddVacancyCommandResponse>> Add([FromForm] AddVacancyCommandRequest request)
            => await Mediator.Send(new AddVacancyCommand(request));

        [HttpGet("vacanciesCached")]
        public async Task<IEnumerable<GetAllVacancyDto>> VacanciesCached()
            => await Mediator.Send(new GetAllVacanciesQueryCached());

        [HttpGet("vacancies")]
        public async Task<IQueryable<GetAllVacancyDto>> getAll()
            => await Mediator.Send(new GetAllVacanciesQuery());


        [HttpGet("vacancies/{id}")]
        public async Task<ServiceResult<GetVacancyByQueryResponse<Vacancy>>> GetById([FromQuery] int id)
            => await Mediator.Send(new GetVacancyByIdQuery(id));

        [HttpGet("vacancies/search")]
        public async Task<ServiceResult<GetVacancyByQueryResponse<Vacancy>>> Search([FromBody] string name)
            => await Mediator.Send(new SearchVacancyQuery(name));


    }
}
