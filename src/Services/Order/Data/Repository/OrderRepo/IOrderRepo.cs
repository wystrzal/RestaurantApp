using Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Data.Repository.MenuRepo
{
    public interface IOrderRepo : IBaseRepository
    {
        Task<IEnumerable<Orders>> GetOrders(bool orderStatusIsPaid);
    }
}
