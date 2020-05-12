using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor httpContext;

        public MenuService(IHttpClient httpClient, IHttpContextAccessor httpContext)
        {
            this.httpClient = httpClient;
            this.httpContext = httpContext;
            baseUrl = "http://localhost:5200/api/menu/";
        }

        public async Task DeleteMenuType(int typeId)
        {
            var deleteTypeUri = ApiPaths.Menu.DeleteMenuType(baseUrl, typeId);

            var accessToken = await httpContext.HttpContext.GetTokenAsync("access_token");

            await httpClient.DeleteAsync(deleteTypeUri, accessToken);
        }

        public async Task DeleteMenuItem(int itemId)
        {
            var deleteItemUri = ApiPaths.Menu.DeleteMenuItem(baseUrl, itemId);

            var accessToken = await httpContext.HttpContext.GetTokenAsync("access_token");

            await httpClient.DeleteAsync(deleteItemUri, accessToken);
        }

        public async Task CreateMenuItem(MenuItem menuItem)
        {
            var postMenuItemUri = ApiPaths.Menu.PostMenuItem(baseUrl);

            var accessToken = await httpContext.HttpContext.GetTokenAsync("access_token");

            await httpClient.PostAsync(postMenuItemUri, menuItem, accessToken);
        }

        public async Task CreateMenuType(MenuType menuType)
        {
            var postMenuTypeUri = ApiPaths.Menu.PostMenuType(baseUrl);

            var accessToken = await httpContext.HttpContext.GetTokenAsync("access_token");

            await httpClient.PostAsync(postMenuTypeUri, menuType, accessToken);
        }

        public async Task<PaginatedItems<MenuItem>> GetMenuItems(int? typeId, int? page)
        {
            var getMenuItemsUri = ApiPaths.Menu.GetMenu(baseUrl, typeId ?? 1, page ?? 0);

            var dataString = await httpClient.GetStringAsync(getMenuItemsUri);

            var response = JsonConvert.DeserializeObject<PaginatedItems<MenuItem>>(dataString);

            return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetMenuTypes()
        {
            var getMenuTypesUri = ApiPaths.Menu.GetTypes(baseUrl);

            var dataString = await httpClient.GetStringAsync(getMenuTypesUri);

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
