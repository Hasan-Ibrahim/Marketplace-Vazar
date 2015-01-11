using System.ComponentModel.DataAnnotations;

namespace Web.Models.Account
{
    public class Registration
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RetypePassword { get; set; }
    }
}
