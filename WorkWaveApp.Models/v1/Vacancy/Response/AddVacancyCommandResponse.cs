﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveApp.Models.v1.Vacancy.Response
{
    public class AddVacancyCommandResponse
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int VacancyId { get; set; }
    }
}
