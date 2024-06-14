namespace EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities
{
    public class LabResults
    {
        public Guid Id { get; set; }
        public string Diagnosis { get; set; }
        public string Test { get; set; }
        public string Results { get; set; }
        public string Prescriptions { get; set; }
        public byte [] TestImage { get; set; }
        public byte[] ResultsImage { get; set; }
    }
}
