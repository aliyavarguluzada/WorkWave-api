using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveApp.Domain.Entities
{
    public class Vacancy : BaseEntity
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
        public string Logo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }

        public virtual Status Status { get; set; }
        public virtual Company Company { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual WorkForm WorkForm { get; set; }
        public virtual City City { get; set; }
        public virtual JobCategory JobCategory { get; set; }
        public virtual Education Education { get; set; }
        public virtual Experience Experience { get; set; }
    }
}
