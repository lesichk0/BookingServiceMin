using BookingService.Data.Interfaces;
using BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Data
{
    public class GuestRepo : GenericRepo<Guest>, IGuestRepo
    {
        private readonly AppDbContext _context;

        public GuestRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Eager Loading
        public async Task<IEnumerable<Guest>> GetGuestsWithReservationsAsync()
        {
            return await _context.Guests.Include(g => g.Reservations).ToListAsync();
        }
    }
}
