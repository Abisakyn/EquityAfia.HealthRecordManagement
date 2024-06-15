using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;
using EquityAfia.HealthRecordManagement.Infrastructure.Configuration.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecords.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<LabResults> LabResults { get; set; }
        public DbSet<HealthRecords> HealthRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations
            modelBuilder.ApplyConfiguration(new LabResultsConfiguration());
            modelBuilder.ApplyConfiguration(new HealthRecordsConfiguration());
            // Add more configurations here if you have other entities
        }
    }
}
