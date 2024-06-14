namespace EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities
{
    public class LabResults
    {
        public Guid Id { get; set; }
        public string Diagnosis { get; set; }
        public string Test { get; set; }
        public string Results { get; set; }
        public string Prescriptions { get; set; }

        // New properties to store image file paths or content
        public string TestImagePath { get; set; }
        public string ResultsImagePath { get; set; }
    }
}
