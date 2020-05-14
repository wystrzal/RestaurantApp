using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Helpers;
using WebMvc.Services.MenuService;
using WebMvc.Services.OrderService;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var user = User.Claims.ToList();
            var vm = await orderService.GetOrders();


            if (user.Any(x => x.Value == "kitchen" || x.Value == "admin"))
            {
                vm = vm.Where(x => x.OrderStatus == CustomEnums.OrderStatus.Created);
            } 
            else if (user.Any(x => x.Value == "restaurant"))
            {
                vm = vm.Where(x => x.OrderStatus == CustomEnums.OrderStatus.Ready);
            }
          
            return View(vm);
        }
    }
}