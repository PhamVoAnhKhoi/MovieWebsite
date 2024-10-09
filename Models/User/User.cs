using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MovieWebsite.Models
{
    public class User : IdentityUser
    {
        // Thông tin bổ sung cho người dùng
        // [Key]
        // public long UserID { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        // // Navigation Properties
        public ICollection<Review> Reviews { get; set; }
        public ICollection<WatchHistory> WatchHistories { get; set; }
    }
}
