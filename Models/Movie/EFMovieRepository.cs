using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebsite.Models
{
    public class EFMovieRepository: IMovieRepository
    {
        private readonly MovieDbContext _context;

        public EFMovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies
                .Include(m => m.Country)
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                .ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(long id)
        {
            return await _context.Movies
                .Include(m => m.Country)
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                .FirstOrDefaultAsync(m => m.MovieID == id);
        }

        public async Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllMoviesAsync();
            }

            return await _context.Movies
                .Include(m => m.Country)
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .Include(m => m.MovieCategories)
                    .ThenInclude(mc => mc.Category)
                .Where(m => m.Title.Contains(searchTerm) || 
                    m.Director.Contains(searchTerm) || 
                    m.MovieGenres.Any(mg => mg.Genre.GenreName.Contains(searchTerm)) ||
                    m.MovieCategories.Any(mc => mc.Category.CategoryName.Contains(searchTerm)))
                .ToListAsync();
        }

        public async Task<IEnumerable<Genre>> GetGenresForMovieAsync(long movieId)
        {
            return await _context.MovieGenres
                .Where(mg => mg.MovieID == movieId)
                .Select(mg => mg.Genre)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesForMovieAsync(long movieId)
        {
            return await _context.MovieCategories
                .Where(mc => mc.MovieID == movieId)
                .Select(mc => mc.Category)
                .ToListAsync();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            // Cập nhật thông tin phim
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task AddMovieAsync(Movie movie)
        {
            
            
            // Thêm các thể loại và danh mục đã chọn
            if (movie.MovieGenres != null && movie.MovieGenres.Any())
            {
                foreach (var movieGenre in movie.MovieGenres)
                {
                    _context.MovieGenres.Add(movieGenre);
                }
            }

            if (movie.MovieCategories != null && movie.MovieCategories.Any())
            {
                foreach (var movieCategory in movie.MovieCategories)
                {
                    _context.MovieCategories.Add(movieCategory);
                }
            }
            // Thêm phim vào DbContext
            _context.Movies.Add(movie);
            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(long? id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
