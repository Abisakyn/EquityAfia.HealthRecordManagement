using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.ViewAllHealthRecordsDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.ViewAllMedicalRecords
{
    public class ViewAllHealthRecordsQuery : IRequest<List<ViewAllHealthRecordsResponse>>
    {
        public ViewAllHealthRecordsDTO ViewAllHealthRecords { get; set; }

        public ViewAllHealthRecordsQuery(ViewAllHealthRecordsDTO viewAllHealthRecordsDTO)
        {
            ViewAllHealthRecords = viewAllHealthRecordsDTO;
        }
    }
}
