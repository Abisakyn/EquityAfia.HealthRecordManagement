using System.Threading.Tasks;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs;
using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces
{
    public interface ILabResultsRepository
    {
        Task<LabResults> GetLabResultsByIdAsync (Guid labResultsId);
        Task AddAsync(LabResults labResults);

        Task<List<LabResults>> GetAllLabResultsAsync(string idNumber);
    }
}
