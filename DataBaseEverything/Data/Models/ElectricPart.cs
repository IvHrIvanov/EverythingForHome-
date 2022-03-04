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
    public class ElectricPart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string PartElectric { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int CabelMeter { get; set; }
        [Url]
        public string ImageUrl { get; set; }

        public int? ShopId { get; set; }
        public Shop Shop { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(225)]
        public string Description { get; set; }
    }
}