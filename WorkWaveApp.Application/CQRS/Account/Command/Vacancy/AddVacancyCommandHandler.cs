using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Models.v1.Vacancy;
using WorkWaveAPP.Application.Core;

namespace WorkWaveApp.Application.CQRS.Account.Command.Vacancy
{
    public class AddVacancyCommandHandler : IRequestHandler<AddVacancyCommand, ServiceResult<VacancyResponse>>
    {
        private readonly IVacancyService _vacancyService;

        public AddVacancyCommandHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }



        Task<ServiceResult<VacancyResponse>> IRequestHandler<AddVacancyCommand, ServiceResult<VacancyResponse>>.Handle(AddVacancyCommand request, CancellationToken cancellationToken)
                => _vacancyService.AddVacancy(request.VacancyRequest);


    }
}
