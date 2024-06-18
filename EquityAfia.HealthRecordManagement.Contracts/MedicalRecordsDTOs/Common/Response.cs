using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.Common
{
    public class Response
    {
        public Guid LabResultsId { get; set; }
        public IFormFile TestImage { get; set; }

        public IFormFile ResultImage { get; set; }

    }
}
