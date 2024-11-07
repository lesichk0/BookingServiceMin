using BookingService.Models;

namespace BookingService.Data.Interfaces
{
    public interface IGuestRepo : IGenericRepo<Guest>
    {
        Task<IEnumerable<Guest>> GetGuestsWithReservationsAsync();
    }
}
