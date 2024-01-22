using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Models.v1.Vacancy;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Account.Query.Vacancy
{
    public class GetVacancyQueryHandler : IRequestHandler<GetVacancyQuery, ServiceResult<VacancyResponse>>
    {
        private readonly IVacancyService _vacancyService;
        public GetVacancyQueryHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }
        public async Task<ServiceResult<VacancyResponse>> Handle(GetVacancyQuery request, CancellationToken cancellationToken)
        {
            var result = await _vacancyService.GetVacancyById(request.VacancyId);

            return result;
        }
    }
}
