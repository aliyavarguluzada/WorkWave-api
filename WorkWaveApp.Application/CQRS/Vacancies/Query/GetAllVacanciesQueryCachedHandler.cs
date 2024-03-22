using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Models.Dtos;

namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class GetAllVacanciesQueryCachedHandler : IRequestHandler<GetAllVacanciesQueryCached, IEnumerable<GetAllVacancyDto>>
    {
        private readonly IVacancyService _vacancyService;
        public GetAllVacanciesQueryCachedHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }
        public async Task<IEnumerable<GetAllVacancyDto>> Handle(GetAllVacanciesQueryCached request, CancellationToken cancellationToken)
             => await _vacancyService.GetAllVacanciesCached();
    }
}
