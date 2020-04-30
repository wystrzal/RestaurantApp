using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        public bool Available { get; set; }

        [Required]
        public int MenuTypeId { get; set; }

        public MenuType MenuType { get; set; }

        public MenuItem()
        {
            Available = true;
        }
    }
}
