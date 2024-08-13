using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWebsite.Models
{
    public interface IMovieReference
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(long id);
        Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm);
    }
}
