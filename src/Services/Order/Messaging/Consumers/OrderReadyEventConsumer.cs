using Common.Messaging;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Messaging.Consumers
{
    public class OrderReadyEventConsumer : IConsumer<OrderReadyEvent>
    {
        public Task Consume(ConsumeContext<OrderReadyEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
