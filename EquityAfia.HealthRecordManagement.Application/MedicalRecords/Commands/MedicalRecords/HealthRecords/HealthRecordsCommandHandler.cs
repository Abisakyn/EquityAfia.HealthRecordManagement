using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs;
using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.HealthRecords
{
    public class HealthRecordsCommandHandler : IRequestHandler<HealthRecordsCommand, Response>
    {
        private readonly IHealthRecordsRepository _healthRecordsRepository;

        public HealthRecordsCommandHandler(IHealthRecordsRepository healthRecordsRepository)
        {
            _healthRecordsRepository = healthRecordsRepository;
        }

        public async Task<Response> Handle(HealthRecordsCommand command, CancellationToken cancellationToken)
        {
            var healthRecordsDTO = command.HealthRecords;

            var date = DateTime.UtcNow;

            var healthRecordsId =Guid.NewGuid();

            var healthRecord = new Domain.MedicalRecordsAggregate.Entities.HealthRecords
            {
                HealthRecordsId = healthRecordsId,
                Date = date,
                Systolic = healthRecordsDTO.Systolic,
                Diastolic = healthRecordsDTO.Diastolic,
                Weight = healthRecordsDTO.Weight,
                Height = healthRecordsDTO.Height,
            };

            await _healthRecordsRepository.AddAsync(healthRecord);

            var response = new Response
            {
                LabResultsId = healthRecordsId,
            };
            return response;
        }
    } 
}
