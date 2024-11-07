using System.ComponentModel.DataAnnotations;

namespace BookingService.Models
{
    public class Room
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        public string RoomType { get; set; }

        [Required]
        public decimal PricePerNight { get; set; }
    }
}
