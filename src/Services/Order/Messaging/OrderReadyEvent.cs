using Common.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Messaging
{
    public class OrderReadyEvent
    {
        public string OrderStatus { get; set; }
    }
}
