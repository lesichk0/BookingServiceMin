using BookingService.Models;

namespace BookingService.Data.Interfaces
{
    public interface IRoomRepo : IGenericRepo<Room>
    {
        Task<IEnumerable<Reservation>> GetRoomsWithReservationsAsync();
    }
}
