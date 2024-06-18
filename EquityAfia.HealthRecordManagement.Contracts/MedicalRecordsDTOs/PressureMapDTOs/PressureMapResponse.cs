using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.PressureMapDTOs
{
    public class PressureMapResponse
    {
        public string[] ChartLabel { get; set; }
        public string[] SystolicData { get; set; }
        public string[] DiastolicData { get; set; }
    }
}
