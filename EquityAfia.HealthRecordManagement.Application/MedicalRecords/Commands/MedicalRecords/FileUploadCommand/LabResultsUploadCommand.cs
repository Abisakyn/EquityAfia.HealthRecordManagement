using MediatR;
using Microsoft.AspNetCore.Http;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.FileUploadCommand
{
    public class LabResultsUploadCommand : IRequest<Guid>
    {
        public string Diagnosis { get; set; }
        public string Test { get; set; }
        public string Results { get; set; }
        public string Prescriptions { get; set; }
        public IFormFile TestImage { get; set; }
        public IFormFile ResultsImage { get; set; }
    }
}
