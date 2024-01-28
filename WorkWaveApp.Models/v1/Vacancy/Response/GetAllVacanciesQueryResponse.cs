using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveApp.Models.v1.Vacancy.Response
{
    public class GetAllVacanciesQueryResponse<T>
    {
       public List<T> Values { get; set; }

    }
}
