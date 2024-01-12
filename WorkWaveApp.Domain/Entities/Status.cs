﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveApp.Domain.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }

    }
}
