using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.Common;
using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;
using EquityAfia.SharedContracts;
using MassTransit;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.HealthRecords
{
    public class HealthRecordsCommandHandler : IRequestHandler<HealthRecordsCommand, HealthRecordsResponse>
    {
        private readonly IHealthRecordsRepository _healthRecordsRepository;
        private readonly IRequestClient<UserExists> _userExistsRequestClient;

        public HealthRecordsCommandHandler(IHealthRecordsRepository healthRecordsRepository, IRequestClient<UserExists> userExistsRequestClient)
        {
            _healthRecordsRepository = healthRecordsRepository;
            _userExistsRequestClient = userExistsRequestClient;
        }

        public async Task<HealthRecordsResponse> Handle(HealthRecordsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var healthRecordsDTO = command.HealthRecords;

                // Check if user exists
                var response = await _userExistsRequestClient.GetResponse<UserExists>(new UserExists
                {
                    IdNumber = healthRecordsDTO.IdNumber!
                });

                var userExistsResponse = response.Message;
                if (userExistsResponse == null)
                {
                    throw new Exception("User does not exist");
                }

                var date = DateTime.UtcNow;
                var healthRecordsId = Guid.NewGuid();

                var healthRecord = new Domain.MedicalRecordsAggregate.Entities.HealthRecords
                {
                    HealthRecordsId = healthRecordsId,
                    Date = date,
                    IdNumber = healthRecordsDTO.IdNumber,
                    Systolic = healthRecordsDTO.Systolic,
                    Diastolic = healthRecordsDTO.Diastolic,
                    Weight = healthRecordsDTO.Weight,
                    Height = healthRecordsDTO.Height,
                    FirstName = userExistsResponse.FirstName,
                    LastName = userExistsResponse.LastName,
                    Email = userExistsResponse.Email
                };

                await _healthRecordsRepository.AddAsync(healthRecord);

                var responseDTO = new HealthRecordsResponse
                {
                    HealthRecordsId = healthRecordsId,
                    Systolic = healthRecordsDTO.Systolic,
                    Diastolic = healthRecordsDTO.Diastolic,
                    Weight = healthRecordsDTO.Weight,
                    Height = healthRecordsDTO.Height
                };

                return responseDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while processing your request", ex);
            }
        }
    }
}
