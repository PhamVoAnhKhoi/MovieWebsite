using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebsite.Models
{
    public class WatchHistory
    {
        [Key]
        public long WatchID { get; set; }

        [Required]
        public long UserID { get; set; }

        [Required]
        public long MovieID { get; set; }

        [Required]
        public DateTime WatchDate { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }
    }
}
