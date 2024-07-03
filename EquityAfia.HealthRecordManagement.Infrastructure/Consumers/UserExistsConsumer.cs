using EquityAfia.SharedContracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Infrastructure.Consumers
{
    public class UserExistsConsumer: IConsumer<UserExists>
    {
        public async Task Consume(ConsumeContext<UserExists> context)
        {
            var message = context.Message;

            Console.WriteLine(message);

            //return Task.CompletedTask;

            //await context.Send(message);

            await Task.Delay(1000);
        }
    }
}
