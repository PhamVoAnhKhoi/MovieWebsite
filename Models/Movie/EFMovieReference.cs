using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebsite.Models
{
    public class EFMovieReference : IMovieReference
    {
        private readonly MovieDbContext _context;

        public EFMovieReference(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

       public async Task<Movie> GetMovieByIdAsync(long id)
        {
            return await _context.Movies.FindAsync(id);
        }


        public async Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Movies.ToListAsync();
            }

            return await _context.Movies
                .Where(m => m.Title.Contains(searchTerm) || m.Genre.Contains(searchTerm) || m.Director.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
