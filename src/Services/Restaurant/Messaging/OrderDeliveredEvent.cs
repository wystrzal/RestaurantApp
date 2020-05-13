using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Messaging
{
    public class OrderDeliveredEvent
    {
        public int OrderId { get; set; }

        public OrderDeliveredEvent(int orderId)
        {
            this.OrderId = orderId;
        }
    }
}
