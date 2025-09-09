using Microsoft.AspNetCore.Mvc;
using RetroVHSRental.Repository;

namespace RetroVHSRental.Controllers
{
    public class MovieController : Controller
    {
        private readonly IfilmRepository _filmRepository;

        public MovieController(IfilmRepository _filmRepository)
        {
            this._filmRepository = _filmRepository;
        }
        public IActionResult Index()
        {
            return View(_filmRepository.GetAllFilmsAsync());
        }

        public IActionResult Details(int id)
        { 
            return View(_filmRepository.GetFilmByIdAsync(id));
        }

    }
}
