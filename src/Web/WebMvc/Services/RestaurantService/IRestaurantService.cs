using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.ViewModels.OrderModels;

namespace WebMvc.Services.RestaurantService
{
    public interface IRestaurantService
    {
        Task OrderReady(int orderId, List<OrderIngredients> orderIngredients);
    }
}
