using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataBaseevEverythingForHome.Models
{
    public class Account : IdentityUser
    {      

        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(28)]
        public string Town { get; set; }
        [Required]
        [MaxLength(80)]
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}