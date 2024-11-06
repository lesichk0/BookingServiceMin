namespace BookingService.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string GuestId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }

        public Guest Guest { get; set; }
        public Room Room { get; set; }
    }
}
