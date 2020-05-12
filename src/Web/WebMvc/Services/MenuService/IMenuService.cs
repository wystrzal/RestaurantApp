using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;
using WebMvc.ViewModels;

namespace WebMvc.Services.MenuService
{
    public interface IMenuService
    {
        Task<PaginatedItems<MenuItem>> GetMenuItems(int? typeId, int? page);
        Task<IEnumerable<SelectListItem>> GetMenuTypes();
        Task CreateMenuItem(MenuItem menuItem);
        Task CreateMenuType(MenuType menuType);
        Task DeleteMenuItem(int itemId);
        Task DeleteMenuType(int typeId);
    }
}
