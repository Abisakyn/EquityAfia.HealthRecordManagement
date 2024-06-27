using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.ViewAllHealthRecordsDTOs
{
    public class ViewAllHealthRecordsResponse 
    {
        public string? Systolic { get; set; }
        public string? Diastolic { get; set; }
        public string? Weight { get; set; }
        public string? Height { get; set; }
    }
}
