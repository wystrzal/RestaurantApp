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
        Task<PaginatedItemsViewModel<MenuItem>> GetMenuItems(int? typeId, int? page);
        Task<IEnumerable<SelectListItem>> GetMenuTypes();
    }
}
