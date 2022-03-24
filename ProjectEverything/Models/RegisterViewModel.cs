using System.ComponentModel.DataAnnotations;

namespace ProjectEverything.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; init; }
        [Required]
        public string Password { get; init; }
        [Required]
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}
