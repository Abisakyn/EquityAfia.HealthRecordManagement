using Azure;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;
//using EquityAfia.HealthRecordManagement.Infrastructure.Persistence;
using MedicalRecords.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Infrastructure.Repositories
{
    public class LabResultsRepository : ILabResultsRepository
    {
        private readonly ApplicationDbContext _context;

        public LabResultsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LabResults labResults)
        {
            await _context.LabResults.AddAsync(labResults);
            await _context.SaveChangesAsync();
        }

        public async Task<LabResults> GetLabResultsByIdAsync(Guid labResultsId)
        {
            return await _context.LabResults.FindAsync(labResultsId);

        }

        public async Task<List<LabResults>> GetAllLabResultsAsync(string idNumber)
        {
            return await _context.LabResults
                .Where(r => r.IdNumber == idNumber)
                //.OrderByDescending(r => r.Date)
                .ToListAsync();
        }
    }
}
