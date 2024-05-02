

namespace WorkWaveApp.Application.CQRS.Account.Command.Vacancy
{
    public class AddVacancyCommand : IRequest<ServiceResult<AddVacancyCommandResponse>>
    {
        public AddVacancyCommand(AddVacancyCommandRequest request)
        {
            VacancyRequest = request;
        }
        public AddVacancyCommandRequest VacancyRequest;
    }
}
