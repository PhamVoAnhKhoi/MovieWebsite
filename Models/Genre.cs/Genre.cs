using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieWebsite.Models
{
    public class Genre
    {
        [Key]
        public long GenreID { get; set; }

        [Required]
        [StringLength(100)]
        public string GenreName { get; set; }

        // Navigation Properties
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public bool Selected { get; set; } // Thêm thuộc tính này để theo dõi trạng thái checkbox
    }
}
