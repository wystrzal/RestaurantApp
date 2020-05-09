using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services.RestaurantService;
using WebMvc.ViewModels;
using WebMvc.ViewModels.OrderModels;

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
        public IActionResult OrderReady([FromBody]OrderIngredientsViewModel orderIngredientsViewModel)
        {
            restaurantService.OrderReady(orderIngredientsViewModel.OrderId, orderIngredientsViewModel.OrderIngredients);

            return Ok();
        }
    }
}