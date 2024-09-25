using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieWebsite.Models
{
    public class Role
    {
        [Key]
        public long RoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        // Navigation Properties
        public ICollection<User> Users { get; set; }
    }
}
