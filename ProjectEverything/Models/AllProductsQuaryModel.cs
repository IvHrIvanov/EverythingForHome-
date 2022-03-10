using System.ComponentModel.DataAnnotations;

namespace ProjectEverything.Models
{
    public class AllProductsQuaryModel
    {
        public const int PartsPerPage = 2;
        public int CurrentPage { get; init; } = 1;
        [Display(Name = "Search")]
        public IEnumerable<string> SearchTerm { get; init; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
