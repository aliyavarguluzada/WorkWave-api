using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveApp.Models.v1.Vacancy.Request
{
    public class AddVacancyCommandRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int CompanyId { get; set; }
        public int JobTypeId { get; set; }
        public int JobCategoryId { get; set; }
        public int WorkFormId { get; set; }
        public int CityId { get; set; }
        public int ExperienceId { get; set; }
        public int EducationId { get; set; }
        public string Email { get; set; }
        public IFormFile Logo { get; set; }
    }
}
