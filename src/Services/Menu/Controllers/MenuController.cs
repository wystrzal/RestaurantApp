using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Menu.Data.Repository;
using Menu.Data.Repository.MenuRepo;
using Menu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        [AllowAnonymous]
        [HttpGet("type/{typeId}")]
        public async Task<IActionResult> GetMenu(int typeId, [FromQuery]int pageIndex = 0 )
        {
            var menu = await menuRepository.GetMenu(typeId, pageIndex);

            return Ok(menu);
        }

        [AllowAnonymous]
        [HttpGet("types")]
        public async Task<IActionResult> GetMenuTypes()
        {
            var menuTypes = await menuRepository.GetAll<MenuType>();

            return Ok(menuTypes);
        }

        [AllowAnonymous]
        [HttpGet("{itemId}")]
        public async Task<IActionResult> GetMenuItem(int itemId)
        {
            var menuItem = await menuRepository.GetById<MenuItem>(itemId);

            if (menuItem == null)
            {
                return NotFound("Could not find menu item.");
            }

            return Ok(menuItem);
        }


        [HttpPost("new/item")]
        public async Task<IActionResult> AddNewItem(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                menuRepository.Add(menuItem);
                if (await menuRepository.SaveAll())
                {
                    return Ok();
                }
                return BadRequest("Could not add menu item.");
            }
            return BadRequest("Model is not valid.");
        }

        [HttpPost("new/type")]
        public async Task<IActionResult> AddNewType(MenuType menuType)
        {
            if (ModelState.IsValid)
            {
                menuRepository.Add(menuType);
                if (await menuRepository.SaveAll())
                {
                    return Ok();
                }
                return BadRequest("Could not add menu item.");
            }
            return BadRequest("Model is not valid.");
        }

        //TODO
        [HttpDelete("delete/{itemId}")]
        public async Task<IActionResult> DeleteItem(int itemId)
        {
            var menuItem = await menuRepository.GetById<MenuItem>(itemId);

            if (menuItem == null)
            {
                return NotFound("Could not find menu item.");
            }

            menuRepository.Delete(menuItem);

            if (await menuRepository.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Could not delete menu item.");
        }

        [HttpDelete("delete/type/{typeId}")]
        public async Task<IActionResult> DeleteType(int typeId)
        {
            var menuType = await menuRepository.GetById<MenuType>(typeId);

            if (menuType == null)
            {
                return NotFound("Could not find menu type.");
            }

            menuRepository.Delete(menuType);

            if (await menuRepository.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Could not delete menu type");
        }
    }
}