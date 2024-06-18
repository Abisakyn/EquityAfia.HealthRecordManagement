using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.Common
{
    public class HealthRecordsDTO
    {
        public DateTime Date { get; set; }
        public string? IdNumber { get; set; }
        public string? Systolic { get; set; }
        public string? Diastolic { get; set; }
        public string? Weight { get; set; }
        public string? Height { get; set; }

    }
}
