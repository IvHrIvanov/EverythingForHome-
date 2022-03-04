using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseevEverythingForHome.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(28)]
        public string Town { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        public ICollection<Account> Accounts { get; set; } = new HashSet<Account>();
        public ICollection<ElectricPart> ElectricParts { get; set; } = new HashSet<ElectricPart>();
        public ICollection<WaterPart> WaterParts { get; set; } = new HashSet<WaterPart>();

    }
}