using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.ViewModels;
using WebMvc.ViewModels.OrderModels;

namespace WebMvc.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderReady([FromBody]OrderIngredientsViewModel orderIngredientsViewModel)
        {

            return RedirectToAction("Index", "Order", null);
        }
    }
}