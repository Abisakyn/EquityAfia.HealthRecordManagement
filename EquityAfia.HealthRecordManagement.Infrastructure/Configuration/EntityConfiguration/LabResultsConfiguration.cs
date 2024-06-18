
using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquityAfia.HealthRecordManagement.Infrastructure.Configuration.EntityConfiguration
{
    public class LabResultsConfiguration : IEntityTypeConfiguration<LabResults>
    {
        public void Configure(EntityTypeBuilder<LabResults> builder)
        {
            //builder.ToTable("LabResults"); // Set the table name

            builder.HasKey(e => e.LabResultsId); // Set the primary key

            builder.Property(e => e.IdNumber)
                .IsRequired();

            builder.Property(e => e.Diagnosis)
                   .IsRequired()
                   .HasMaxLength(100); 

            builder.Property(e => e.Test)
                   .IsRequired();

            builder.Property(e => e.Results)
                   .IsRequired();

            builder.Property(e => e.Prescriptions)
                   .HasMaxLength(200); 

            
        }
    }
}
