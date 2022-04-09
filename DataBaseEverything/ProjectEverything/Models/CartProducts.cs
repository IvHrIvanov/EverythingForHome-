using DataBaseevEverythingForHome.Models;

namespace ProjectEverything.Models
{
    public class CartProducts
    {
        public int ProductId { get; set; }
        public string AccountId { get; init; }
        public int Quantity { get; init; }
        public Product Product { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
