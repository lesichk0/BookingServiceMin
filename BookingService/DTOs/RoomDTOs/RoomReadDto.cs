namespace BookingService.DTOs.RoomDTOs
{
    public class RoomReadDto
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }
    }
}
