using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.ViewAllLabResultsDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.ViewAllLabResults
{
    public  class ViewAllLabResultsQuery : IRequest<List<ViewAllLabResultsDTOResponse>>
    {
        public ViewAllLabResultsDTO LabResults { get; set; }

        public ViewAllLabResultsQuery(ViewAllLabResultsDTO viewAllLabResultsDTO)
        {
            LabResults = viewAllLabResultsDTO;
        }
    }
}
