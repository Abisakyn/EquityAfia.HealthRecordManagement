using MassTransit;
using System.Threading.Tasks;
using EquityAfia.HealthRecordManagement.Contracts.Events.UserExist;

public class UserExistConsumer : IConsumer<UserExistEvent>
{
    public Task Consume(ConsumeContext<UserExistEvent> context)
    {
        var message = context.Message;

        // Implement your logic here to handle the UserExistEvent message
        // Example: Log the event or trigger further processing

        return Task.CompletedTask;
    }
}
