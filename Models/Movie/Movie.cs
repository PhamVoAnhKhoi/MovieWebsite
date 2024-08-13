// Models/Movie.cs
namespace MovieWebsite.Models
{
    public class Movie
    {
        public long? MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string MovieImage { get; set; }
        public string MovieUrl {get; set;}
    }
}
