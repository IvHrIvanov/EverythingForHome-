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
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(80)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirtDate { get; set; }
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
        public Shop Shop { get; set; }
    }
}