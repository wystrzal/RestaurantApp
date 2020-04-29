using Menu.Data.Repository.BaseRepository;
using Menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Data.Repository.MenuRepo
{
    public class MenuRepository : BaseRepository<MenuItem>, IMenuRepository
    {
        private readonly DataContext dataContext;
        public MenuRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
