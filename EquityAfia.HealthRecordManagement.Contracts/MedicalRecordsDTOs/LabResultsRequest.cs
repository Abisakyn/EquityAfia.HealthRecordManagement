using System;

namespace EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs
{
    public class LabResultsRequest
    {
        public string Diagnosis { get; set; }
        public string Test { get; set; }
        public string Results { get; set; }
        public string Prescriptions { get; set; }
    }
}
