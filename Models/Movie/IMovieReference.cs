using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWebsite.Models
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(long id);
        Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm);
        Task<IEnumerable<Genre>> GetGenresForMovieAsync(long movieId);
        Task<IEnumerable<Category>> GetCategoriesForMovieAsync(long movieId);
        Task UpdateMovieAsync(Movie movie);
        Task AddMovieAsync(Movie movie);
        Task DeleteMovieAsync(long? id);
    }
}
