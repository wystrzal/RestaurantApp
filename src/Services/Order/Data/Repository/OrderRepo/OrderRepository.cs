using Microsoft.EntityFrameworkCore;
using Order.Data;
using Order.Data.Repository;
using Order.Data.Repository.MenuRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Data.Repository.MenuRepo
{
    public class OrderRepository : BaseRepository, IOrderRepo
    {
        private readonly DataContext dataContext;
        public OrderRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
