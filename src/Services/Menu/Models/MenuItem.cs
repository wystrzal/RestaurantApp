using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public bool Available { get; set; }

        public int MenuTypeId { get; set; }

        public MenuType MenuType { get; set; }

        public MenuItem()
        {
            Available = true;
        }
    }
}
