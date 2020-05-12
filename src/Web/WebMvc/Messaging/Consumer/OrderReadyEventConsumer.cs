using Common.Messaging;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Messaging.SignalR;

namespace WebMvc.Messaging.Consumer
{
    public class OrderReadyEventConsumer : IConsumer<OrderReadyEvent>
    {
        private readonly IHubContext<SignalServerHub> hubContext;

        public OrderReadyEventConsumer(IHubContext<SignalServerHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<OrderReadyEvent> context)
        {
            await hubContext.Clients.All.SendAsync("OrderReady");
        }
    }
}
