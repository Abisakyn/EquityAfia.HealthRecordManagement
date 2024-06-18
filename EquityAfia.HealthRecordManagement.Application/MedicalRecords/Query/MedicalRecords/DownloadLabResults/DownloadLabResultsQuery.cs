using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.DownloadLabResults
{
    public class DownloadLabResultsQuery : IRequest<DownloadLabResultsResponse>
    {
        public DownloadLabResultsDTO DownloadLabResultsDTO { get; set; }

        public DownloadLabResultsQuery (DownloadLabResultsDTO downloadLabResultsDTO)
        {
            DownloadLabResultsDTO = downloadLabResultsDTO;
        }
    }
}
