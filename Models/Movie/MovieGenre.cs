using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebsite.Models
{
    public class MovieGenre
    {
        public long MovieID { get; set; }
        public long GenreID { get; set; }

        // Navigation Properties
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
