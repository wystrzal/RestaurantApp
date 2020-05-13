using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Dto
{
    public class MenuForAddTypeDto
    {
        [Required]
        public string Type { get; set; }
    }
}
