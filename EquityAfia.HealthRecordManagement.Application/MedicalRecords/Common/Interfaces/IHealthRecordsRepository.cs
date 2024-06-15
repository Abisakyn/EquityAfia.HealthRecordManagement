using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces
{
    public interface IHealthRecordsRepository
    {
        Task<HealthRecords> GetHealthRecordsByHealthRecordsIdAsync(Guid HealthRecordsId);
        Task AddAsync(HealthRecords healthRecords);
    }
}
