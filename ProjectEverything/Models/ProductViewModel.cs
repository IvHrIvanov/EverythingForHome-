using System.ComponentModel.DataAnnotations;

namespace ProjectEverything.Models
{
    public class ProductViewModel
    {

        public int Id { get; set; }
        public string Part { get; init; }
        
        public decimal Price { get; init; }
     
        public int Quantity { get; set; }

        public string Year { get; set; }
   
        public string ImageUrl { get; set; }
 
        public string Description { get; set; }
    }
}
