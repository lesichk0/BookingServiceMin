namespace BookingService.DTOs.ReservationDTOs
{
    public class ReservationReadDto
    {
        public int Id { get; set; }
        public string GuestId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }
    }
}
