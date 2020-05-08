using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class MenuIngredientsItems
    {
        [Required]
        public int MenuItemId { get; set; }

        public MenuItem MenuItem { get; set; }

        [Required]
        public int MenuIngredientId { get; set; }

        public MenuIngredient MenuIngredient { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
    }
}
