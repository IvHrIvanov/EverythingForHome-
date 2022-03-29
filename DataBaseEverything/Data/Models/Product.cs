using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseevEverythingForHome.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Part { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public decimal Price { get; set; } = 0.00m;
        [Required]
        public int Quantity { get; set; } = 0;
        public int QuantityBuy { get; set; } = 0;
        
        [Required]
        [Url]
        public string ImageUrl { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(225)]
        public string Description { get; set; }
    }
}