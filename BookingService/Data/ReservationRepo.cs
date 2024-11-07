using BookingService.Data.Interfaces;
using BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Data
{
    public class ReservationRepo : GenericRepo<Reservation>, IReservationRepo
    {
        private readonly AppDbContext _context;

        public ReservationRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        //Eager Loading
        public async Task<IEnumerable<Reservation>> GetReservationsWithGuestsAsync()
        {
            return await _context.Reservations.Include(r => r.Guest).ToListAsync();
        }
    }
}
