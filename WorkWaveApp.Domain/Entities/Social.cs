using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveApp.Domain.Entities
{
    public class Social : BaseEntity
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public Company Company { get; set; }

    }
}
