using AutoMapper;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.Common;
using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<HealthRecords, HealthRecordsDTO>();
            CreateMap<LabResults, LabResultsDTO>();
        }
    }
}
