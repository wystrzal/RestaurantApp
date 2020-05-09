using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Messaging;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IBus bus;

        public RestaurantController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpPost("{orderId}")]
        public async Task<IActionResult> OrderReady(int orderId, List<OrderIngredients> orderIngredients)
        {
            await bus.Publish(new OrderReadyEvent() { OrderId = orderId, OrderIngredients = orderIngredients });
            return Ok();
        }

    }
}