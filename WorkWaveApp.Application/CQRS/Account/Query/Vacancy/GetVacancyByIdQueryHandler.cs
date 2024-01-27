using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Domain.Entities;

namespace WorkWaveApp.Application.CQRS.Account.Query.Vacancy
{
    public class GetVacancyByIdQueryHandler : IRequestHandler<GetVacancyByIdQuery, Domain.Entities.Vacancy>
    {
        private readonly IVacancyService _vacancyService;

        public GetVacancyByIdQueryHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public Task<Domain.Entities.Vacancy> Handle(GetVacancyByIdQuery request, CancellationToken cancellationToken)
        {
            var vacancy = _vacancyService.GetVacancyById(request.VacancyId);

            return vacancy;
        }
    }
}
