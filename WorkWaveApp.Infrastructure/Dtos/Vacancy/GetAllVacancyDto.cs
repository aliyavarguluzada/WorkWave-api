using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveApp.Infrastructure.Dtos.Vacancy
{
    public class GetAllVacancyDto
    {
        public int VacancyId { get; set; }
        public string VacancyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
   
}
