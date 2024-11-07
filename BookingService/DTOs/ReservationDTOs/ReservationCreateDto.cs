using System.ComponentModel.DataAnnotations;

namespace BookingService.DTOs.ReservationDTOs
{
    public class ReservationCreateDto
    {
        [Required]
        public string GuestId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
