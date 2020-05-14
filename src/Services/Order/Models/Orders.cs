using Order.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public CustomEnums.OrderStatus OrderStatus { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public Orders()
        {
            OrderDate = DateTime.Now;
        }

    }
}
