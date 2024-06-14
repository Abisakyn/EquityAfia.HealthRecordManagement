using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.FileUploadCommand
{
    public class LabResultsUploadCommand : IRequest<Response>
    {
        public LabResultsDTO LabResults { get; set; }
        public LabResultsUploadCommand(LabResultsDTO labResults)
        {
            LabResults = labResults;
        }
    }
}
       
 

