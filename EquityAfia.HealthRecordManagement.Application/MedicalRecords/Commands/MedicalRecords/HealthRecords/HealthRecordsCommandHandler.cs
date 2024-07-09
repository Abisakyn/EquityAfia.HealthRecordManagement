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
        private readonly IPublishEndpoint _publishEndpoint;

        public HealthRecordsCommandHandler(IHealthRecordsRepository healthRecordsRepository, IRequestClient<UserExists> userExistsRequestClient, IPublishEndpoint publishEndpoint)
        {
            _healthRecordsRepository = healthRecordsRepository;
            _userExistsRequestClient = userExistsRequestClient;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<HealthRecordsResponse> Handle(HealthRecordsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var healthRecordsDTO = command.HealthRecords;

                var userExistsRequest = new UserExists
                {
                    IdNumber = healthRecordsDTO.IdNumber
                };

                // Publish UserExists event
                await _publishEndpoint.Publish(userExistsRequest);

                // Wait for response from UserExists check with explicit timeout
                var response = await _userExistsRequestClient.GetResponse<UserExists>(userExistsRequest, cancellationToken);

                // Check if user exists based on the response
                if (!response.Message.Exists)
                {
                    throw new Exception("User does not exist");
                }

                // User exists, proceed with recording health records
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
                    FirstName = response.Message.FirstName,
                    LastName = response.Message.LastName,
                    Email = response.Message.Email
                };

                // Add health record to repository
                await _healthRecordsRepository.AddAsync(healthRecord);

                // Prepare and return response DTO
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
            catch (RequestTimeoutException ex)
            {
                // Handle request timeout exception
                throw new Exception("The request timed out while waiting for a response.", ex);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions and propagate
                throw new Exception("An error occurred while processing your request", ex);
            }
        }
    }
}
