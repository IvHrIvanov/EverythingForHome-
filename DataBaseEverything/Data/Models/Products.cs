using System.ComponentModel.DataAnnotations;

namespace DataBaseevEverythingForHome.Models
{
    public class Products
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

        [Required]
        [Url]
        public string ImageUrl { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(225)]
        public string Description { get; set; }
        public int? ShopId { get; set; }
        public Shop Shop { get; set; }
       
    }
}