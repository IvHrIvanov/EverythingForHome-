using System.ComponentModel.DataAnnotations;

namespace DataBaseevEverythingForHome.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [MaxLength(28)]
        public string Town { get; set; }
        [Required]
        [MaxLength(80)]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }

        public int? ShopId { get; set; } 
        public Shop Shop { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}