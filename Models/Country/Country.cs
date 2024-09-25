using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieWebsite.Models
{
    public class Country
    {
        [Key]
        public long CountryID { get; set; }

        [Required]
        [StringLength(100)]
        public string CountryName { get; set; }

        // Navigation Properties
        public ICollection<Movie> Movies { get; set; }
    }
}
