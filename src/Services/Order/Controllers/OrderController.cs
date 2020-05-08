using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Data.Repository.MenuRepo;
using Order.Dto;
using Order.Models;

namespace Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo orderRepo;
        private readonly IMapper mapper;

        public OrderController(IOrderRepo orderRepo, IMapper mapper)
        {
            this.orderRepo = orderRepo;
            this.mapper = mapper;
        }

        [HttpGet("delivered")]
        public async Task<IActionResult> GetDeliveredOrders()
        {
            var orders = await orderRepo.GetOrders(true);

            return Ok(orders);
        }
            
        [Authorize(Policy = "Admin")]
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
        public async Task<IActionResult> NewOrderClient(OrderForAddClientDto order)
        {
            var orderForAdd = mapper.Map<Orders>(order);

            orderForAdd.OrderStatus = "created";

            orderRepo.Add(orderForAdd);

            if (await orderRepo.SaveAll())
            {
                return CreatedAtAction("GetOrder", new { orderId = orderForAdd.OrderId }, order);
            }
            return BadRequest("Could not add order");
        }

        [HttpPost("worker")]
        public async Task<IActionResult> NewOrderWorker(OrderForAddWorkerDto order)
        {
            var orderForAdd = mapper.Map<Orders>(order);

            orderForAdd.OrderStatus = "created";

            orderRepo.Add(orderForAdd);

            if (await orderRepo.SaveAll())
            {
                return CreatedAtAction("GetOrder", new { orderId = orderForAdd.OrderId }, order);
            }
            return BadRequest("Could not add order");
        }
    }
};