
namespace WorkWaveApp.Application.CQRS.Vacancies.Query
{
    public class GetVacancyByIdQuery : IRequest<ServiceResult<GetVacancyByQueryResponse<Vacancy>>>
    {
        public GetVacancyByIdQuery(int id)
        {
            VacancyId = id;
        }
        public int VacancyId { get; set; }


    }
}
