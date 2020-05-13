using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Dto
{
    public class OrderForAddItemDto
    {
        [Required]
        public string ProductName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        public int Quantity { get; set; }
        public OrderForAddClientDto OrderForAddDto { get; set; }
    }
}
