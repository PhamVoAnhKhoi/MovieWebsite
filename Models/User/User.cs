using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebsite.Models
{
    public class User
    {
        [Key]
        public long UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; } // Mật khẩu đã mã hóa

        [Required]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public long? RoleID { get; set; }

        // Navigation Properties
        [ForeignKey("RoleID")]
        public Role Role { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<WatchHistory> WatchHistories { get; set; }
    }
}
