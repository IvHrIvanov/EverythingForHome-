using System.ComponentModel.DataAnnotations;

namespace DataBaseevEverythingForHome.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(28)]
        public string Town { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        public ICollection<Account> Accounts { get; set; } = new HashSet<Account>();
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}