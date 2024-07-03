
using MassTransit;
using EquityAfia.SharedContracts;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.EventHandler
{
    public class UserExistsEventHandler : IConsumer<UserExists>
    {
        private readonly IHealthRecordsRepository _healthRecordsRepository;

        public UserExistsEventHandler(IHealthRecordsRepository healthRecordsRepository)
        {
            _healthRecordsRepository = healthRecordsRepository;
        }

        public async Task Consume(ConsumeContext<UserExists> context)
        {
            var userExists = context.Message;

            var firstName = userExists.FirstName;

            var lastName = userExists.LastName;

            var email = userExists.Email;

            var date = DateTime.UtcNow;

            var healthRecordsId = Guid.NewGuid();

            var healthRecords = new HealthRecords
            {
                HealthRecordsId = healthRecordsId,
                Date = date,
                FirstName = firstName,
                LastName = lastName,
                Email = email,

            };

        }
    }
}