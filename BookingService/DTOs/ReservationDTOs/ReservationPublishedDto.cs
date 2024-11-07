namespace BookingService.DTOs.ReservationDTOs
{
    public class ReservationPublishedDto
    {
        public int Id { get; set; }
        public string GuestId { get; set; }
        public int RoomId { get; set; }
        public string Status { get; set; }
        public string Event { get; set; }
    }
}
