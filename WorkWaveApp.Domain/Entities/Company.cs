using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveApp.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
        public ICollection<Social> Socials { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
