using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebsite.Models
{
    public class Movie
    {
        [Key]
        public long MovieID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int Duration { get; set; } // Thời lượng tính bằng phút

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(255)]
        public string Director { get; set; }

        [StringLength(500)]
        public string Cast { get; set; }

        [StringLength(500)]
        public string PosterURL { get; set; }

        [StringLength(500)]
        public string VideoURL { get; set; }

        // Foreign Key
        public long CountryID { get; set; }

        // Navigation Properties
        [ForeignKey("CountryID")]
        public Country Country { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<WatchHistory> WatchHistories { get; set; } = new List<WatchHistory>();
        public ICollection<MovieCategory> MovieCategories { get; set; } = new List<MovieCategory>();
    }
}
