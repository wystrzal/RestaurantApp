using Menu.Data.Repository.MenuRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Data.Repository
{
    public interface IRepositoryWrapper
    {
        IMenuRepository MenuRepository { get; }
    }
}
