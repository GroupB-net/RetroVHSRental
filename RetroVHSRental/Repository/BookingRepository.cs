using RetroVHSRental.Models;
using RetroVHSRental.Data;
using Microsoft.EntityFrameworkCore;

namespace RetroVHSRental.Repository
{
    public class BookingRepository: IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings.Include(b => b.Film)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(b => b.BookingId == id);
        }
        public async Task<IEnumerable<Booking>> GetBookingsByCustomerEmailAsync(string Email)
        {
            return await _context.Bookings
                .Where(b => b.Customer.Email == Email)
                .ToListAsync();
        }
        public async Task AddBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }


    }
}
