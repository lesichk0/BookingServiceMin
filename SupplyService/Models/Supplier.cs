using System.ComponentModel.DataAnnotations;

namespace SupplyService.Models
{
    public class Supplier
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string ContactInfo { get; set; }

        [StringLength(200)]
        public string Address { get; set; } 
    }
}
