using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class CreateMenuTypeViewModel
    {
        public MenuType MenuType { get; set; }
        public IEnumerable<SelectListItem> SelectListTypes { get; set; }
    }
}
