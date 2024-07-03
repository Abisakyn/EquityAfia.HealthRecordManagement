

namespace EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities
{
    public class HealthRecords
    {
        public Guid HealthRecordsId {  get; set; }
        public string? IdNumber { get; set; }
        public string? FirstName { get; set; }

        public string LastName { get; set; }  
        public string? Email { get; set; }
        public DateTime Date {  get; set; } 
        public string? Systolic { get; set; }
        public string? Diastolic { get; set; }
        public string? Weight { get; set; }
        public string? Height { get; set; }
    }
}
