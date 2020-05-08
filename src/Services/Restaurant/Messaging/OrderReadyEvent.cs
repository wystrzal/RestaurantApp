using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Messaging
{
    public class OrderReadyEvent
    {
        public int OrderId { get; set; }
        public int MyProperty { get; set; }
        public IEnumerable<OrderIngredients> OrderIngredients { get; set; }
    }
    public class OrderIngredients
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
