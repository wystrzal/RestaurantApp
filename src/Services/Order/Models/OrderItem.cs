using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        public Orders Order { get; set; }
    }
}
