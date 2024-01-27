using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkWaveApp.Application.CQRS.Account.Command.Vacancy;
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
        
    }
}
