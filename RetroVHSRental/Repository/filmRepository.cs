using RetroVHSRental.Models;
using RetroVHSRental.Data;
using Microsoft.EntityFrameworkCore;
namespace RetroVHSRental.Repository
{
    public class filmRepository: IfilmRepository

    {
        private readonly ApplicationDbContext _context;
        public filmRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<film>> GetAllFilmsAsync()
        {
            return await _context.films.ToListAsync();
        }
        public async Task<film> GetFilmByIdAsync(int id)
        {
            return await _context.films.FirstOrDefaultAsync(m=>m.film_id==id);
        }
        public async Task<IEnumerable<film>> SearchAsynk(string title)
        {

            return await _context.films
                .Where(f => f.title.Contains(title))
                .ToListAsync();
        }
        public async Task UpdateAsync(film film)
        {
            _context.films.Update(film);
            await _context.SaveChangesAsync();
        }

    }
}
