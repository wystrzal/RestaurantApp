using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using RabbitMQ.Client.Framing.Impl;
using WebMvc.Models;
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
            var menu = await menuService.GetMenuItems(TypeId ?? 0, page ?? 0);

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

        [HttpPost]
        public async Task<IActionResult> CreateItem(MenuItem menuItem)
        {
            var vm = new CreateMenuItemViewModel
            {
                MenuType = await menuService.GetMenuTypes()
            };

            if (ModelState.IsValid)
            {
                await menuService.CreateMenuItem(menuItem);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        public async Task<IActionResult> CreateType()
        {
            var vm = new CreateMenuTypeViewModel
            {
                SelectListTypes = await menuService.GetMenuTypes()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateType(MenuType menuType)
        {
            var vm = new CreateMenuTypeViewModel
            {
                SelectListTypes = await menuService.GetMenuTypes()
            };

            if (ModelState.IsValid)
            {
                await menuService.CreateMenuType(menuType);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        public async Task<IActionResult> DeleteItem([FromBody]int itemId)
        {
            await menuService.DeleteMenuItem(itemId);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteType([FromBody]int typeId)
        {
            await menuService.DeleteMenuType(typeId);

            return RedirectToAction("CreateType");
        }

    }
}