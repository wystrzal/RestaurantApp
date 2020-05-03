using Menu.Data.Repository;
using Menu.Models;
using Menu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Data.Repository.MenuRepo
{
    public interface IMenuRepository : IBaseRepository
    {
        Task<PaginatedItemsViewModel<MenuItem>> GetMenu(int typeId, int pageIndex);
    }
}
