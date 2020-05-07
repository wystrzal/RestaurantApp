using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.Services.OrderService
{
    public interface IOrderService
    {
        Task<IEnumerable<Orders>> GetOrders();
    }
}
