using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkWaveApp.Application.CQRS.Account.Command.Vacancy;
using WorkWaveApp.Application.CQRS.Vacancies.Query;
using WorkWaveApp.Domain.Entities;
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

        [HttpPost("addVacancy"), Authorize(Roles = "company")]
        public async Task<ServiceResult<AddVacancyCommandResponse>> AddVacancy([FromForm] AddVacancyCommandRequest request)
            => await Mediator.Send(new AddVacancyCommand(request));

        [HttpGet("getAllVacanciesCached")]
        public async Task<IEnumerable<GetAllVacancyDto>> GetAllVacanciesCached()
            => await Mediator.Send(new GetAllVacanciesQueryCached());

        [HttpGet("getAllVacancies")]
        public async Task<IEnumerable<GetAllVacancyDto>> GetAllVacancies()
            => await Mediator.Send(new GetAllVacanciesQuery());

        [HttpPost("getVacancyById")]
        public async Task<ServiceResult<GetVacancyByQueryResponse<Vacancy>>> GetVacancyById([FromBody] int id)
            => await Mediator.Send(new GetVacancyByIdQuery(id));

        [HttpPost("searchVacancy")]
        public async Task<ServiceResult<GetVacancyByQueryResponse<Vacancy>>> SearchVacancy([FromBody] string vacancyName)
            => await Mediator.Send(new SearchVacancyQuery(vacancyName));


    }
}
