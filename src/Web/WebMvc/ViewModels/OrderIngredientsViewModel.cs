using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.ViewModels.OrderModels;

namespace WebMvc.ViewModels
{
    public class OrderIngredientsViewModel
    {
        public int OrderId { get; set; }
        public IEnumerable<OrderIngredients> OrderIngredients { get; set; }
    }
}
