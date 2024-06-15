using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;
using MedicalRecords.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Infrastructure.Repositories
{
    public class HealthRecordsRepositories : IHealthRecordsRepository
    {
        private readonly ApplicationDbContext _context;
        public HealthRecordsRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(HealthRecords healthRecords)
        {
            await _context.HealthRecords.AddAsync(healthRecords);
            await _context.SaveChangesAsync();
        }

        public async Task <HealthRecords> GetHealthRecordsByHealthRecordsIdAsync(Guid healthRecordsId)
        {
            return await _context.HealthRecords
                .FirstOrDefaultAsync(u => u.HealthRecordsId == healthRecordsId);
        }
    }
}
