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

        public int? AccountId { get; set; }
        public Account Account { get; set; }

        public ICollection<Products> Products { get; set; } = new List<Products>();

    }
}
