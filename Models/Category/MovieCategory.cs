using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebsite.Models
{
    public class MovieCategory
    {
        public long MovieID { get; set; }
        public long CategoryID { get; set; }

        // Navigation Properties
        public Movie Movie { get; set; }
        public Category Category { get; set; }
    }
}
