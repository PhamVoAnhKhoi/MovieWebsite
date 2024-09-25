using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebsite.Models
{
    public class Review
    {
        [Key]
        public long ReviewID { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; } // Đánh giá sao (1-5)

        [Required]
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        public long UserID { get; set; }
        public long MovieID { get; set; }

        // Navigation Properties
        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }
    }
}
