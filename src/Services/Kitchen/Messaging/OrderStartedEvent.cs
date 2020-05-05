using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Messaging
{
    public class OrderStartedEvent
    {
        public int OrderId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Table { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItemEvent> OrderItems { get; set; }

        public OrderStartedEvent(int orderId, string phoneNumber, string address, string table, OrderStatus orderStatus,
            decimal totalPrice, ICollection<OrderItemEvent> orderItems)
        {
            OrderId = orderId;
            PhoneNumber = phoneNumber;
            Address = address;
            Table = table;
            OrderStatus = orderStatus;
            TotalPrice = totalPrice;
            OrderItems = orderItems;
        }
    }
    public class OrderItemEvent
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
    public enum OrderStatus
    {
        Created = 1,
        Ready = 2,
        Delivered = 3,
        Paid = 4
    }
}
