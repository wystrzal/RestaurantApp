using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class MenuViewModel
    {
        public int TypeId { get; set; }
        public IEnumerable<MenuItem> MenuItem { get; set; }
        public IEnumerable<SelectListItem> MenuType { get; set; }
    }
}
