using Common.Messaging;
using MassTransit;
using Order.Data.Repository.MenuRepo;
using Order.Helpers;
using Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Messaging.Consumers
{
    public class OrderDeliveredEventConsumer : IConsumer<OrderDeliveredEvent>
    {
        private readonly IOrderRepo orderRepo;

        public OrderDeliveredEventConsumer(IOrderRepo orderRepo)
        {
            this.orderRepo = orderRepo;
        }
        public async Task Consume(ConsumeContext<OrderDeliveredEvent> context)
        {
            var order = await orderRepo.GetById<Orders>(context.Message.OrderId);
            order.OrderStatus = CustomEnums.OrderStatus.Delivered;
            orderRepo.Update(order);
            await orderRepo.SaveAll();
        }
    }
}
