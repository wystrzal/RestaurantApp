using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Messaging
{
    public class OrderReadyEvent
    {
        public int OrderId { get; set; }
        public OrderReadyEvent(int orderId)
        {
            this.OrderId = orderId;
        }
    }
}
