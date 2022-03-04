using DataBaseevEverythingForHome.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseevEverythingForHome.Models
{
    public class WaterPart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string PartWater { get; set; }
        [Required]
        public decimal Price { get; set; } = 0;
        [Required]
        public int Quantity { get; set; } = 0;

        public int? ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}