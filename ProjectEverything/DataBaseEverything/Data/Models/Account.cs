using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseevEverythingForHome.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Username { get; init; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(80)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; init; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; init; }
        [Required]
        public DateTime BirtDate { get; init; }
        [Required]
        [MaxLength(28)]
        public string City { get; set; }
        [Required]
        [MaxLength(80)]
        public string Address { get; set; }
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        public int? ShopId { get; set; } 
        public Maggazine Shop { get; set; }
    }
}