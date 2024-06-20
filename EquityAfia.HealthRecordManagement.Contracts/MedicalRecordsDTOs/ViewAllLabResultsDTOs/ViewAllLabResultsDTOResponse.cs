using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.ViewAllLabResultsDTOs
{
    public class ViewAllLabResultsDTOResponse
    {
      
        public string? Diagnosis { get; set; }
        public string? Test { get; set; }
        public string? Results { get; set; }
        public string? Prescriptions { get; set; }
        public string? IdNumber { get; set; }
        public IFormFile? TestImage { get; set; }
        public IFormFile? ResultsImage { get; set; }
    }
}
