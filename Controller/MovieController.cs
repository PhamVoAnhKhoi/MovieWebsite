using Microsoft.AspNetCore.Mvc;
using MovieWebsite.Models;
using System.Threading.Tasks;

namespace MovieWebsite.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieReference;

        public MovieController(IMovieRepository movieReference)
        {
            _movieReference = movieReference;
        }

        // Hiển thị danh sách phim
        public async Task<IActionResult> Index()
        {
            var movies = await _movieReference.GetAllMoviesAsync();
            return View(movies);
        }

        // Hiển thị chi tiết một phim theo ID
        public async Task<IActionResult> Details(long id)
        {
            var movie = await _movieReference.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // Thêm phim mới
        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieReference.AddMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // Xóa phim
        public async Task<IActionResult> Delete(long id)
        {
            await _movieReference.DeleteMovieAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
