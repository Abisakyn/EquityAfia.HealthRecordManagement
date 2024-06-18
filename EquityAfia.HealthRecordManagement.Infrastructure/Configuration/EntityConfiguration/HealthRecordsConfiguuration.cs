using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Infrastructure.Configuration.EntityConfiguration
{
    public class HealthRecordsConfiguration : IEntityTypeConfiguration<HealthRecords>
    {
        public void Configure(EntityTypeBuilder<HealthRecords> builder)
        {
            builder.HasKey(e => e.HealthRecordsId);

            builder.Property(e =>e.IdNumber).IsRequired();

            builder.Property(e => e.Date).IsRequired();

            builder.Property(e => e.Systolic)
                   .IsRequired();

            builder.Property(e => e.Diastolic)
                .IsRequired();

            builder.Property(e => e.Weight) .IsRequired();

            builder.Property(e =>e.Height) .IsRequired();
        }
    }
}
