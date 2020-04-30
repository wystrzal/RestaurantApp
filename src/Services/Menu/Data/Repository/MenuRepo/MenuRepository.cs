using Menu.Data.Repository;
using Menu.Models;
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
    }
}
