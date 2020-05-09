using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Helpers
{
    public static class CustomEnums
    {
        public enum OrderStatus
        {
            Created = 1,
            Ready = 2,
            Delivered = 3
        }
    }
}
