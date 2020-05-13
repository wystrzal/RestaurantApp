using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Menu.Data.Repository;
using Menu.Data.Repository.MenuRepo;
using Menu.Dto;
using Menu.Dto.AutoMapper;
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
        private readonly IMapper mapper;

        public MenuController(IMenuRepository menuRepository, IMapper mapper)
        {
            this.menuRepository = menuRepository;
            this.mapper = mapper;
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

            var menuForReturn = mapper.Map<IEnumerable<MenuForReturnTypesDto>>(menuTypes);

            return Ok(menuForReturn);
        }

        [HttpPost("new/item")]
        public async Task<IActionResult> AddNewItem(MenuForAddItemDto menuForAddItemDto)
        {
            var menuItemForAdd = mapper.Map<MenuItem>(menuForAddItemDto);

            menuRepository.Add(menuItemForAdd);

            if (await menuRepository.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Could not add menu item.");
        }

        [HttpPost("new/type")]
        public async Task<IActionResult> AddNewType(MenuForAddTypeDto menuForAddTypeDto)
        {
            var menuTypeForAdd = mapper.Map<MenuType>(menuForAddTypeDto);

            menuRepository.Add(menuTypeForAdd);

            if (await menuRepository.SaveAll())
            {
                return Ok();
            }
            
            return BadRequest("Could not add menu item.");
        }


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