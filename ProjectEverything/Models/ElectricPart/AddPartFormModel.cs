using System.ComponentModel.DataAnnotations;

namespace ProjectEverything.Models.ElectricPart
{
    public class AddPartFormModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Part name must be between {2} and {1} symbols!")]
        [Display(Name = "Part")]
        public string PartElectric { get; init; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Price need to be between {1} and {2} money!")]
        public decimal Price { get; init; }
        [Required]
        public int Quantity { get; set; }
        [Required]

        public string Year { get; set; }
        [Required]
        [Range(0, 10000)]
        public int CabelMeter { get; set; }
        [Required]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Description text must need to be between {2} and {1} symbols!")]
        public string Description { get; set; }
    }
}
