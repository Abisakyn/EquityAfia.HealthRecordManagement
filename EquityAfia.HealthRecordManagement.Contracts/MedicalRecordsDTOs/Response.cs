﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs
{
    public class Response
    {
        public Guid UserId { get; set; }
        public string? FileName { get; set; }

    }
}
