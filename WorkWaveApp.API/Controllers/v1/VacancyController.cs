using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkWaveApp.Application.CQRS.Account.Command.Vacancy;
using WorkWaveApp.Application.CQRS.Account.Query.Vacancy;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Models.v1.Vacancy;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.API.Controllers.v1
{
    [Route("api/v{version:apiversion}/vacancy")]
    [ApiController]
    [ApiVersion("1.0")]
    public class VacancyController : BaseController
    {
        private readonly IMediator _mediator;

        public VacancyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("addVacancy")]
        public async Task<ServiceResult<VacancyResponse>> AddVacancy([FromBody] VacancyRequest request)
            => await _mediator.Send(new AddVacancyCommand(request));

        [HttpGet("getAllVacancies")]
        public async Task<IEnumerable<Vacancy>> GetAllVacancies()
            => await _mediator.Send(new GetAllVacanciesQuery());

        [HttpPost("getVacancyById")]
        public async Task<Vacancy> GetVacancyById([FromBody] int id)
            => await _mediator.Send(new GetVacancyByIdQuery(id));

        

    }
}
