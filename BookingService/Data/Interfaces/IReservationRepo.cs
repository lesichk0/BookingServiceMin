using BookingService.Models;

namespace BookingService.Data.Interfaces
{
    public interface IReservationRepo : IGenericRepo<Reservation>
    {
        Task<IEnumerable<Reservation>> GetReservationsWithGuestsAsync();
    }
}
