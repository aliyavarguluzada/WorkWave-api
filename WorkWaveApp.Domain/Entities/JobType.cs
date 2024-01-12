﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveApp.Domain.Entities
{
    public class JobType : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }

    }
}
