using System.ComponentModel.DataAnnotations;

namespace DataBaseevEverythingForHome.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderNumber { get; init; }
        [Required]
        public string OrderedProduct { get; set; } 
        [Required]
        public decimal TotalPrice { get; set; } = 0;

        public int? BuyerId { get; set; }
        public Account Account { get; set; }
        public ICollection<Products> Products { get; set; } = new List<Products>();
            
    }
}
