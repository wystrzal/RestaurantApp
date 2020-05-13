using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebMvc.Messaging.SignalR;
using WebMvc.Models;
using WebMvc.Services.RestaurantService;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }
       
        [HttpPost]
        public async Task<IActionResult> OrderReady([FromBody]int orderId)
        {
            await restaurantService.OrderReady(orderId);       

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> OrderDelivered([FromBody]int orderId)
        {
            await restaurantService.OrderDelivered(orderId);

            return Ok();
        }
    }
}