using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.HealthRecords
{
    public class HealthRecordsCommand :IRequest<Response>
    {
        public HealthRecordsDTO HealthRecords { get; set; }

        public HealthRecordsCommand (HealthRecordsDTO healthRecords)
        {
            HealthRecords = healthRecords;
        }
    }
}
