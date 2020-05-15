using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{
    public class User : IdentityUser
    { 
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must have minimum 6 signs.")]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
