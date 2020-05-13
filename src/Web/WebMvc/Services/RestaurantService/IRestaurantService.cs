using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Services.RestaurantService
{
    public interface IRestaurantService
    {
        Task OrderReady(int orderId);
        Task OrderDelivered(int orderId);
    }
}
