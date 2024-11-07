using BookingService.Data.Interfaces;
using BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Data
{
    public class RoomRepo : GenericRepo<Room>, IRoomRepo
    {
        private readonly AppDbContext _context;

        public RoomRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Eager Loading
        public async Task<IEnumerable<Reservation>> GetRoomsWithReservationsAsync()
        {
            return await _context.Reservations
                .Include(r => r.Room)
                .Include(r => r.Guest)
                .ToListAsync();
        }
    }
}
