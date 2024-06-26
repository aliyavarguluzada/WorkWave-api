﻿namespace WorkWaveApp.Application.CQRS.Account.Command.Vacancy
{
    public class AddVacancyCommandHandler : IRequestHandler<AddVacancyCommand, ServiceResult<AddVacancyCommandResponse>>
    {
        private readonly IVacancyService _vacancyService;

        public AddVacancyCommandHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }



        Task<ServiceResult<AddVacancyCommandResponse>> IRequestHandler<AddVacancyCommand, ServiceResult<AddVacancyCommandResponse>>.Handle(AddVacancyCommand request, CancellationToken cancellationToken)
                => _vacancyService.AddVacancy(request.VacancyRequest);


    }
}
