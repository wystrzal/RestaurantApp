using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Dto
{
    public class OrderForAddClientDto
    { 
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItemForAddDto> OrderItems { get; set; }
    }
}
