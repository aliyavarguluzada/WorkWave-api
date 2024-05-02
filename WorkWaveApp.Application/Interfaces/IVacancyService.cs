
namespace WorkWaveApp.Application.Interfaces
{
    public interface IVacancyService
    {
        Task<ServiceResult<AddVacancyCommandResponse>> AddVacancy(AddVacancyCommandRequest request);
        Task<ServiceResult<GetVacancyByQueryResponse<Vacancy>>> GetVacancyById(int Id);
        Task<ServiceResult<GetVacancyByQueryResponse<Vacancy>>> SearchVacancy(string VacancyName);
        //Task<ServiceResult<GetAllVacanciesQueryResponse<Vacancy>>> GetAllVacancies();
        Task<IEnumerable<GetAllVacancyDto>> GetAllVacanciesCached();
        Task<IQueryable<GetAllVacancyDto>> GetAllVacancies();
        Task<List<Vacancy>> GetVac();
    }
}
