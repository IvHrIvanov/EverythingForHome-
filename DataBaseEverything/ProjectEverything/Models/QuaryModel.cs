using System.ComponentModel.DataAnnotations;

namespace ProjectEverything.Models
{
    public class QuaryModel
    {
        public const int PartsPerPage = 3;
        public int ProductId { get; set; }
        public string AccountId { get; set; }
        public int CurrentPage { get; init; } = 1;
        [Display(Name = "Search")]
        public string SearchTerm { get; init; }
        [Required]
        [Range(0,100)]
        [Display(Name ="Quantity")]
        public int QuantityBuy { get; init; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
