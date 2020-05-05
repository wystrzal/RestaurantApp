using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Messaging;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBus bus;

        public OrderController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpPost]
        public IActionResult Test()
        {
            var orderItem = new List<OrderItemEvent>() { new OrderItemEvent() { Quantity = 1, ProductName = "Burger" } };
            var order = new OrderStartedEvent(1, null, null, "1", OrderStatus.Created, 13M, orderItem);


            bus.Publish(order).Wait();
            return Ok();
        }
    }
};