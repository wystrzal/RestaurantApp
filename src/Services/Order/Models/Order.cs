using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Table { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public Orders()
        {
            OrderDate = DateTime.Now;
        }

    }
}
