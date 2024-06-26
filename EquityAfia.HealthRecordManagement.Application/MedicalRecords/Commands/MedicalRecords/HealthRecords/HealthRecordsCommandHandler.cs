using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using EquityAfia.HealthRecordManagement.Contracts.Events.UserExist;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.Common;
using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.HealthRecords
{
    public class HealthRecordsCommandHandler : IRequestHandler<HealthRecordsCommand, HealthRecordsResponse>
    {
        private readonly IHealthRecordsRepository _healthRecordsRepository;
        //private readonly IRequestClient<UserExistEvent> _userExistsRequestClient;

        public HealthRecordsCommandHandler(IHealthRecordsRepository healthRecordsRepository)
        {
            _healthRecordsRepository = healthRecordsRepository;
            //_userExistsRequestClient = userExistsRequestClient;
        }

        public async Task<HealthRecordsResponse> Handle(HealthRecordsCommand command, CancellationToken cancellationToken)
        {
            var healthRecordsDTO = command.HealthRecords;

            //// Check if user exists
            //var response = await _userExistsRequestClient.GetResponse<UserExistResponse>(
            //    new UserExistEvent { IdNumber = healthRecordsDTO.IdNumber });

            //if (!response.Message.Exists)
            //{
            //    throw new Exception("User does not exist");
            //}

            var date = DateTime.UtcNow;

            var healthRecordsId =Guid.NewGuid();

            var healthRecord = new Domain.MedicalRecordsAggregate.Entities.HealthRecords
            {
                HealthRecordsId = healthRecordsId,
                Date = date,
                IdNumber = healthRecordsDTO.IdNumber,
                Systolic = healthRecordsDTO.Systolic,
                Diastolic = healthRecordsDTO.Diastolic,
                Weight = healthRecordsDTO.Weight,
                Height = healthRecordsDTO.Height,
            };

            await _healthRecordsRepository.AddAsync(healthRecord);

            var responseDTO = new HealthRecordsResponse
            {
                HealthRecordsId = healthRecordsId,
                Systolic=healthRecordsDTO.Systolic,
                Diastolic=healthRecordsDTO.Diastolic,
                Weight = healthRecordsDTO.Weight,
                Height=healthRecordsDTO.Height,
            };
            return responseDTO;
        }
    } 
}
