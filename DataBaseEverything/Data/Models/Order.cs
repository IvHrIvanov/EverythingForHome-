using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseevEverythingForHome.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderNumber { get; init; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
