using Common.Messaging;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Messaging.Consumers
{
    public class OrderStartedEventConsumer : IConsumer<OrderStartedEvent>
    {
        public async Task Consume(ConsumeContext<OrderStartedEvent> context)
        {
            await Console.Out.WriteLineAsync($"Updating customer: {context.Message.OrderItems}");
        }
    }
}
