using System.ComponentModel.DataAnnotations;

namespace ProjectEverything.Models.ElectricPart
{
    public class AddPartViewModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string PartElectric { get; init; }
        [Required]
        [Range(0, 18)]
        public decimal Price { get; init; }
    }
}
