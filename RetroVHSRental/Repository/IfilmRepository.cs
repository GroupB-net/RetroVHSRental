using RetroVHSRental.Models;

namespace RetroVHSRental.Repository
{
    public interface IfilmRepository
    {
        Task<IEnumerable<film>> GetAllFilmsAsync();
        Task<film> GetFilmByIdAsync(int id);
        Task <IEnumerable<film>> SearchAsynk(string title);
        Task UpdateAsync(film film);
    }
}
