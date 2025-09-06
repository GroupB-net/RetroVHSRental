using RetroVHSRental.Models;
namespace RetroVHSRental.Repository
{
    public interface IBookingRepository
    {
        Task<Booking> GetBookingByIdAsync(int id);
        Task<IEnumerable<Booking>> GetBookingsByCustomerEmailAsync(string Email);
        Task AddBookingAsync(Booking booking);
        Task UpdateBookingAsync(Booking booking);
    }
}
