using Menu.Data.Repository;
using Menu.Models;
using Menu.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Data.Repository.MenuRepo
{
    public class MenuRepository : BaseRepository, IMenuRepository
    {
        private readonly DataContext dataContext;
        public MenuRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<PaginatedItemsViewModel<MenuItem>> GetMenu(int typeId, int pageIndex)
        {
            var totalItems = await dataContext.MenuItems.Where(m => m.MenuTypeId == typeId).CountAsync();

            var menu = await dataContext.MenuItems
                .Where(m => m.MenuTypeId == typeId)
                .OrderBy(m => m.Name).Skip(5 * pageIndex).Take(5).ToListAsync();

            var menuToReturn = new PaginatedItemsViewModel<MenuItem>(pageIndex, totalItems, menu);

            return menuToReturn;
        }
    }
}
