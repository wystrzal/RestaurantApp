using System.ComponentModel.DataAnnotations;


namespace Identity.Models.ViewModels
{
    public class RegisterDto
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        // kitchen / restaurant
        [Required]
        public string Role { get; set; }
    }
}
