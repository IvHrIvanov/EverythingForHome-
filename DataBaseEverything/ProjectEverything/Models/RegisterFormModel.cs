using System.ComponentModel.DataAnnotations;

namespace ProjectEverything.Models
{
    public class RegisterFormModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; init; }
        [Required]
        [StringLength(60, MinimumLength = 8)]
        public string Password { get; init; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; init; }
        [Required]
        [StringLength(30, MinimumLength = 3)]

        public string LastName { get; init; }
        [Required]
        [StringLength(28, MinimumLength = 3)]
        public string Town { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
    }
}
