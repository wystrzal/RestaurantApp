using Menu.Data.Repository.MenuRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Data.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DataContext dataContext;

        public RepositoryWrapper(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        private IMenuRepository menuRepository;
        public IMenuRepository MenuRepository
        {
            get
            {
                if (menuRepository == null)
                {
                    menuRepository = new MenuRepository(dataContext);
                }
                return menuRepository;
            }
        }
    }
}
