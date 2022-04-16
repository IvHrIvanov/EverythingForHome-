using System.ComponentModel.DataAnnotations;

namespace ProjectEverything.Models.ElectricPart
{
    public class ProductFormModel
    {

        public int id { get; init; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Part name must be between {2} and {1} symbols!")]
        public string Part { get; init; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Price need to be between {1} and {2} money!")]
        public decimal Price { get; init; }

        [Required]
        [Range(0, 10000, ErrorMessage = "Price need to be between {1} and {2} quantity!")]
        public int Quantity { get; init; }
        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string Year { get; init; }
        [Required]
        [Display(Name = "Image URL")]
        [Url(ErrorMessage = "Wrong URL format!")]
        public string ImageUrl { get; init; }
        [Required]
        [StringLength(225, MinimumLength = 5, ErrorMessage = "Description text must need to be between {2} and {1} symbols!")]
        public string Description { get; init; }
    }
}
