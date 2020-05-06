using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infractructure;
using WebMvc.Models;
using WebMvc.ViewModels;

namespace WebMvc.Services.MenuService
{

    public class MenuService : IMenuService
    {
        private readonly string baseUrl;
        private readonly IHttpClient httpClient;

        public MenuService(IHttpClient httpClient)
        {
            this.httpClient = httpClient;
            baseUrl = "http://localhost:5200/api/menu/";
        }

        public async Task<PaginatedItemsViewModel<MenuItem>> GetMenuItems(int? typeId, int? page)
        {
            var menuItems = ApiPaths.Menu.GetMenu(baseUrl, typeId ?? 1, page ?? 0);

            var dataString = await httpClient.GetStringAsync(menuItems);

            var response = JsonConvert.DeserializeObject<PaginatedItemsViewModel<MenuItem>>(dataString);

            return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetMenuTypes()
        {
            var menuTypes = ApiPaths.Menu.GetTypes(baseUrl);

            var dataString = await httpClient.GetStringAsync(menuTypes);

            var response = JsonConvert.DeserializeObject<IEnumerable<MenuType>>(dataString);

            var selectList = new List<SelectListItem>();

            foreach (var item in response)
            {
                selectList.Add(new SelectListItem { Text = item.Type, Value = item.Id.ToString() });
            }

            return selectList;
        }
    }
}
