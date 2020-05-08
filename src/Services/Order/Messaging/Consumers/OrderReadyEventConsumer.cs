using Order.Messaging;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Order.Data.Repository.MenuRepo;
using Order.Models;

namespace Order.Messaging.Consumers
{
    public class OrderReadyEventConsumer : IConsumer<OrderReadyEvent>
    {
        private readonly IOrderRepo orderRepo;

        public OrderReadyEventConsumer(IOrderRepo orderRepo)
        {
            this.orderRepo = orderRepo;
        }
        public async Task Consume(ConsumeContext<OrderReadyEvent> context)
        {
            var order = await orderRepo.GetById<Orders>(context.Message.OrderId);
            order.OrderId = context.Message.OrderId;
            orderRepo.Update<Orders>(order);
            await orderRepo.SaveAll(); 
        }
    }
}
