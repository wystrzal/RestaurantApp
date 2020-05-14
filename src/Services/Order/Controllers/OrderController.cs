using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Messaging;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Data.Repository.MenuRepo;
using Order.Dto;
using Order.Helpers;
using Order.Models;

namespace Order.Controllers
{
    [Authorize(Policy = "Worker")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo orderRepo;
        private readonly IMapper mapper;
        private readonly IBus bus;

        public OrderController(IOrderRepo orderRepo, IMapper mapper, IBus bus)
        {
            this.orderRepo = orderRepo;
            this.mapper = mapper;
            this.bus = bus;
        }

        [HttpGet("delivered")]
        public async Task<IActionResult> GetDeliveredOrders()
        {
            var orders = await orderRepo.GetOrders(true);

            return Ok(orders);
        }
            
        [HttpGet]
        public async Task<IActionResult> GetNotDeliveredOrders()
        {
            var orders = await orderRepo.GetOrders(false);

            return Ok(orders);
        }


        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            var order = await orderRepo.GetById<Orders>(orderId);

            if (order != null)
            {
                return Ok(order);
            }

            return BadRequest("Could not find order");
        }

        [AllowAnonymous]
        [HttpPost("client")]
        public async Task<IActionResult> NewOrderClient(OrderForAddDto order)
        {
            var orderForAdd = mapper.Map<Orders>(order);

            orderForAdd.OrderStatus = CustomEnums.OrderStatus.Created;

            orderRepo.Add(orderForAdd);

            if (await orderRepo.SaveAll())
            {
                await bus.Publish(new OrderCreatedEvent());
                return CreatedAtAction("GetOrder", new { orderId = orderForAdd.OrderId }, order);
            }
            return BadRequest("Could not add order");
        }
    }
};