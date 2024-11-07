using System.ComponentModel.DataAnnotations;

namespace BookingService.DTOs.RoomDTOs
{
    public class RoomCreateDto
    {
        [Required]
        public string RoomNumber { get; set; }

        public string RoomType { get; set; }

        [Required]
        public decimal PricePerNight { get; set; }
    }
}
