using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services.MenuService;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        public async Task<IActionResult> Index(int? TypeId, int? page)
        {
            var menu = await menuService.GetMenuItems(TypeId ?? 1, page ?? 0);

            var vm = new MenuViewModel {
                MenuItem = menu.Data,
                MenuType = await menuService.GetMenuTypes() 
            };

            return View(vm);
        }

        public async Task<IActionResult> CreateItem()
        {
            var vm = new CreateMenuItemViewModel
            {
                MenuType = await menuService.GetMenuTypes()
            };

            return View(vm);
        }
    }
}