using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.PressureMapDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.PressureMap
{
    public class PressureMapQuery: IRequest<PressureMapResponse>
    {
        public PressureMapDTO HealthRecords { get; set; }   
        
        public PressureMapQuery(PressureMapDTO pressureMapDTO) 
        {
            HealthRecords = pressureMapDTO;
        }
    }
}
