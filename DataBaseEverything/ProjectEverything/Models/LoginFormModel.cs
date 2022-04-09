using System.ComponentModel.DataAnnotations;

namespace ProjectEverything.Models
{
    public class LoginFormModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        [StringLength(60, MinimumLength = 8)]
        public string Password { get; init; }
    }
}
