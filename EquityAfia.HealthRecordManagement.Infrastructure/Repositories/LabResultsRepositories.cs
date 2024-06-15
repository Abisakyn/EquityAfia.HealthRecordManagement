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
    }
}
